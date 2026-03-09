using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.Collections.Generic;
using System.IO;

namespace Convert_PDF_to_PDFA2A_conformance_document
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var numPages = 0;
            //Set the PDF merge options.
            var pdfMergeOptions = new PdfMergeOptions
            {
                //Enable the Merge Accessibility Tags.
                MergeAccessibilityTags = true,
                OptimizeResources = true
            };
            //Create an array to store the PDF document streams.
            var streamInArray = new Stream[]
            {
               File.OpenRead(Path.GetFullPath("Input.pdf")),
               File.OpenRead(Path.GetFullPath("Input.pdf"))
            };
            //Create a list to store the PDF document streams.
            var streamInList = new List<MemoryStream>();

            foreach (var stream in streamInArray)
            {
                stream.Position = 0;
                //Load the PDF document.
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);
                //Set the compression options.
                loadedDocument.CompressionOptions = new PdfCompressionOptions()
                {
                    CompressImages = false,
                    OptimizeFont = false,
                    OptimizePageContents = false,
                    RemoveMetadata = true
                };
                //Save the document into stream.
                MemoryStream ms = new MemoryStream();
                loadedDocument.Save(ms);
                loadedDocument.Close(true);
                streamInList.Add(new MemoryStream(ms.ToArray()));
            }


            using (var intermediatePdfStream = new MemoryStream())
            {
                //Create a new PDF document with PDF/A-2A conformance level.
                using (var pdfDocument = new PdfDocument(PdfConformanceLevel.Pdf_A2A))
                {
                    //Set the AutoTag property to true.
                    pdfDocument.AutoTag = true;
                    //Set the PDF version to 1.7.
                    pdfDocument.FileStructure.Version = PdfVersion.Version1_7;
                    //Merge the PDF documents into a single PDF document.
                    PdfDocumentBase.Merge(pdfDocument, pdfMergeOptions, streamInList.ToArray());
                    numPages = pdfDocument.Pages.Count;
                    //Save the document into stream.
                    pdfDocument.Save(Path.GetFullPath("Output/Output.pdf"));
                    //Close the document. 
                    pdfDocument.Close(true);
                }
            }


        }
    }
}
