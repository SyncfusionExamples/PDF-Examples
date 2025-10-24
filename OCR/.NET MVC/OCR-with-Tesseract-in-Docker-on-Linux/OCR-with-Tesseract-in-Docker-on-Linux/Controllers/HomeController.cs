using Microsoft.AspNetCore.Mvc;
using OCR_with_Tesseract_in_Docker_on_Linux.Models;
using Syncfusion.Drawing;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.Diagnostics;
using System.Xml.Linq;

namespace OCR_with_Tesseract_in_Docker_on_Linux.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult PerformOCR()
        {
            string docPath = Path.GetFullPath(@"Data/Input.pdf");
            //Initialize the OCR processor.
            using (OCRProcessor processor = new OCRProcessor())
            {
                FileStream fileStream = new FileStream(docPath, FileMode.Open, FileAccess.Read);
                //Load a PDF document
                PdfLoadedDocument lDoc = new PdfLoadedDocument(fileStream);
                //Set OCR language to process
                processor.Settings.Language = Languages.English;
                IOcrEngine tesseractEngine = new Tesseract5OCREngine();
                processor.ExternalEngine = tesseractEngine;
                //Process OCR by providing the PDF document.
                processor.PerformOCR(lDoc);
                //Create memory stream
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the document to memory stream
                    lDoc.Save(stream);
                    lDoc.Close();
                    //Set the position as '0'
                    stream.Position = 0;
                    //Download the PDF document in the browser
                    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
                    fileStreamResult.FileDownloadName = "Sample.pdf";
                    return fileStreamResult;
                }
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    // Tesseract5OcrEngine implementation
    class Tesseract5OCREngine : IOcrEngine
    {
        private float imageHeight;
        private float imageWidth;

        public OCRLayoutResult PerformOCR(Stream stream)
        {
            if (stream == null || !stream.CanRead)
                throw new ArgumentException("Input stream is null or not readable for OCR.", nameof(stream));

            stream.Position = 0;

            using (MemoryStream tempMemStream = new MemoryStream())
            {
                stream.CopyTo(tempMemStream);
                tempMemStream.Position = 0;
                PdfTiffImage pdfTiffImage = new PdfTiffImage(tempMemStream);
                imageHeight = pdfTiffImage.Height;
                imageWidth = pdfTiffImage.Width;
            }

            string tempImageFile = Path.GetTempFileName();
            string tempHocrFile = tempImageFile + ".hocr";

            // Write stream to temp image file
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
                    throw new Exception($"Tesseract process failed with exit code {process.ExitCode}. Error: {errorOutput}");

                if (!File.Exists(tempHocrFile))
                    throw new Exception("HOCR output file not found. Tesseract might have failed or not produced output.");

                hocrText = File.ReadAllText(tempHocrFile);
            }

            // Clean up temp files
            if (File.Exists(tempImageFile)) File.Delete(tempImageFile);
            if (File.Exists(tempHocrFile)) File.Delete(tempHocrFile);

            if (string.IsNullOrEmpty(hocrText))
                throw new Exception("HOCR text could not be generated or was empty.");

            var ocrLayoutResult = new OCRLayoutResult();
            BuildOCRLayoutResult(ocrLayoutResult, hocrText, imageWidth, imageHeight);
            ocrLayoutResult.ImageWidth = imageWidth;
            ocrLayoutResult.ImageHeight = imageHeight;

            return ocrLayoutResult;
        }

        void BuildOCRLayoutResult(OCRLayoutResult ocr, string hOcrText, float imageWidth, float imageHeight)
        {
            var doc = XDocument.Parse(hOcrText, LoadOptions.None);
            var ns = "http://www.w3.org/1999/xhtml";

            foreach (var pageElement in doc.Descendants(ns + "div").Where(d => d.Attribute("class")?.Value == "ocr_page"))
            {
                Page ocrPage = new Page();

                foreach (var lineElement in pageElement.Descendants(ns + "span")
                    .Where(s => s.Attribute("class")?.Value == "ocr_line" || s.Attribute("class")?.Value == "ocr_header"))
                {
                    Line ocrLine = new Line();

                    foreach (var wordElement in lineElement.Descendants(ns + "span")
                        .Where(s => s.Attribute("class")?.Value == "ocrx_word"))
                    {
                        Word ocrWord = new Word { Text = wordElement.Value };
                        String title = wordElement.Attribute("title")?.Value;

                        if (title != null)
                        {
                            String bboxString = title.Split(';')[0].Replace("bbox", "").Trim();
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
}
