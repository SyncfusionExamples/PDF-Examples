using Syncfusion.Drawing;       
using Syncfusion.OCRProcessor;     
using Syncfusion.Pdf.Graphics;     
using Syncfusion.Pdf.Parsing;       
using System.Diagnostics;           
using System.Xml.Linq;             
using System;                       
using System.IO;                    
using System.Linq;                  

// Main application logic
class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPdfPath = Path.GetFullPath(@"Data/Input.pdf");
        string outputPdfPath = Path.GetFullPath(@"Output/Output.pdf");
        string outputTextPath = Path.GetFullPath(@"Output/Output.txt");

        // Use 'using' statements for proper resource disposal
        using (OCRProcessor processor = new OCRProcessor())
        {
            using (FileStream stream = new FileStream(inputPdfPath, FileMode.Open, FileAccess.Read))
            {
                using (PdfLoadedDocument lDoc = new PdfLoadedDocument(stream))
                {
                    processor.Settings.Language = Languages.English;
                    IOcrEngine tesseractEngine = new Tesseract5OcrEngine();
                    processor.ExternalEngine = tesseractEngine;

                    Console.WriteLine("Performing OCR using Tesseract engine...");

                    // Perform OCR on the loaded PDF document.
                    // The result will be the extracted text from the PDF.
                    string extractedText = processor.PerformOCR(lDoc);

                    // Save the modified PDF (e.g., with hidden text layer from OCR)
                    using (FileStream fileStream = new FileStream(outputPdfPath, FileMode.Create))
                    {
                        lDoc.Save(fileStream);
                    }
                    Console.WriteLine($"OCR processed PDF saved to '{outputPdfPath}'.");

                    // Save the extracted text to a .txt file
                    File.WriteAllText(outputTextPath, extractedText);
                    Console.WriteLine($"Extracted text saved to '{outputTextPath}'.");
                }
            }
        }

        Console.WriteLine("Application finished. Press any key to exit.");
        Console.ReadKey();
    }
}

// Tesseract5OcrEngine implementation
class Tesseract5OcrEngine : IOcrEngine
{
    private float imageHeight;
    private float imageWidth;

    public OCRLayoutResult PerformOCR(Stream stream)
    {
        if (stream == null || !stream.CanRead)
        {
            throw new ArgumentException("Input stream is null or not readable for OCR.", nameof(stream));
        }
        stream.Position = 0;

        // Determine image dimensions
        using (MemoryStream tempMemStream = new MemoryStream())
        {
            stream.CopyTo(tempMemStream);
            tempMemStream.Position = 0;
            PdfTiffImage pdfTiffImage = new PdfTiffImage(tempMemStream); // Assumes compatible image utility
            imageHeight = pdfTiffImage.Height;
            imageWidth = pdfTiffImage.Width;
        }

        string tempImageFile = Path.GetTempFileName();
        string tempHocrFile = tempImageFile + ".hocr";

        try
        {
            // Write input stream to temporary image file
            using (FileStream tempFileStream = new FileStream(tempImageFile, FileMode.Create, FileAccess.Write))
            {
                stream.Position = 0;
                stream.CopyTo(tempFileStream);
            }

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "tesseract",
                Arguments = $"\"{tempImageFile}\" \"{tempImageFile}\" -l eng hocr",
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            string hocrText = null;
            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                string errorOutput = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"Tesseract process failed with exit code {process.ExitCode}. Error: {errorOutput}");
                }

                if (File.Exists(tempHocrFile))
                {
                    hocrText = File.ReadAllText(tempHocrFile);
                }
                else
                {
                    throw new Exception("HOCR output file not found. Tesseract might have failed or not produced output.");
                }
            }

            if (string.IsNullOrEmpty(hocrText))
            {
                throw new Exception("HOCR text could not be generated or was empty.");
            }

            OCRLayoutResult oCRLayoutResult = new OCRLayoutResult();
            BuildOCRLayoutResult(oCRLayoutResult, hocrText, imageWidth, imageHeight);
            oCRLayoutResult.ImageWidth = imageWidth;
            oCRLayoutResult.ImageHeight = imageHeight;

            return oCRLayoutResult;
        }
        finally
        {
            if (File.Exists(tempImageFile)) File.Delete(tempImageFile);
            if (File.Exists(tempHocrFile)) File.Delete(tempHocrFile);
            Console.WriteLine("Temporary Tesseract files cleaned up.");
        }
    }

    void BuildOCRLayoutResult(OCRLayoutResult ocr, string hOcrText, float imageWidth, float imageHeight)
    {
        XDocument doc = XDocument.Parse(hOcrText, LoadOptions.None);
        XNamespace ns = "http://www.w3.org/1999/xhtml";

        foreach (var pageElement in doc.Descendants(ns + "div").Where(d => d.Attribute("class")?.Value == "ocr_page"))
        {
            Page ocrPage = new Page();

            foreach (var lineElement in pageElement.Descendants(ns + "span")
                                                  .Where(s => s.Attribute("class")?.Value == "ocr_line" ||
                                                              s.Attribute("class")?.Value == "ocr_header"))
            {
                Line ocrLine = new Line();

                foreach (var wordElement in lineElement.Descendants(ns + "span").Where(s => s.Attribute("class")?.Value == "ocrx_word"))
                {
                    Word ocrWord = new Word { Text = wordElement.Value };

                    string title = wordElement.Attribute("title")?.Value;
                    if (title != null)
                    {
                        string bboxString = title.Split(';')[0].Replace("bbox", "").Trim();
                        int[] coords = bboxString.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                        if (coords.Length == 4)
                        {
                            float x = coords[0];
                            float y = coords[1];
                            float width = coords[2] - coords[0];
                            float height = coords[3] - coords[1];
                            ocrWord.Rectangle = new RectangleF(x, y, width, height);
                        }
                    }
                    ocrLine.Add(ocrWord);
                }
                ocrPage.Add(ocrLine);
            }
            ocr.Add(ocrPage);
        }
    }
}