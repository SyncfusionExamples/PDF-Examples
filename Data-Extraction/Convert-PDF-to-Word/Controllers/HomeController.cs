using Convert_PDF_to_Word.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.SmartDataExtractor;

namespace Convert_PDF_to_Word.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Converts an entire PDF document to a Word document.
        /// </summary>
        public IActionResult ConvertPDFtoWord()
        {
            // Open the input PDF document.
            using FileStream stream = new FileStream("Data/Input-file.pdf", FileMode.Open, FileAccess.Read);
            
            // Create a DataExtractor instance.
            DataExtractor extractor = new DataExtractor();
            
            // Extract PDF content as a Word document.
            WordDocument document = extractor.ExtractDataAsWordDocument(stream);
            
            // Create a memory stream for the output document.
            MemoryStream outputStream = new MemoryStream();
            
            // Save the Word document in DOCX format.
            document.Save(outputStream, FormatType.Docx);
            
            // Close the Word document.
            document.Close();
            
            // Reset the stream position.
            outputStream.Position = 0;

            // Return the generated DOCX file.
            return File(
                outputStream,
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "Output.docx");
        }

        /// <summary>
        /// Converts selected PDF pages to Word.
        /// </summary>
        public IActionResult PDFRangetoWord()
        {
            // Open the input PDF document.
            using FileStream stream = new FileStream("Data/Input-file.pdf", FileMode.Open, FileAccess.Read);

            // Create a DataExtractor instance.
            DataExtractor extractor = new DataExtractor();

            // Specify the page range to convert.
            extractor.PageRange = new int[,] { { 1, 2 } };

            // Extract PDF content as a Word document.
            WordDocument document = extractor.ExtractDataAsWordDocument(stream);

            // Create a memory stream for the output document.
            MemoryStream outputStream = new MemoryStream();

            // Save the Word document in DOCX format.
            document.Save(outputStream, FormatType.Docx);

            // Close the Word document.
            document.Close();

            // Reset the stream position.
            outputStream.Position = 0;

            // Return the generated DOCX file.
            return File(
                outputStream,
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "Output.docx");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
