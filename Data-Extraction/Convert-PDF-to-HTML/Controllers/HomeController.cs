using Convert_PDF_to_HTML.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Syncfusion.SmartDataExtractor;

namespace Convert_PDF_to_HTML.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConvertPDFtoHTML()
        {
            // Open the input PDF file as a FileStream.
            using FileStream stream = new FileStream("Data/Input.pdf", FileMode.Open, FileAccess.Read);

            // Create an instance of the Smart Data Extractor.
            DataExtractor extractor = new DataExtractor();

            // Extract the PDF content as HTML.
            string htmlContent = extractor.ExtractDataAsHtml(stream);

            // Convert the HTML content to a byte array.
            byte[] htmlBytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);

            // Return the HTML content as a downloadable HTML file.
            return File(
                htmlBytes,
                "text/html",
                "Output.html");
        }

        public IActionResult PDFRangetoHTML()
        {
            // Open the input PDF file as a FileStream.
            using FileStream stream = new FileStream("Data/Input.pdf", FileMode.Open, FileAccess.Read);

            // Create an instance of the Smart Data Extractor.
            DataExtractor extractor = new DataExtractor();

            //Set the page range for conversion (example: pages 1 to 2).
            extractor!.PageRange = new int[,] { { 1, 2 } };

            // Extract the PDF content as HTML.
            string htmlContent = extractor.ExtractDataAsHtml(stream);

            // Convert the HTML content to a byte array.
            byte[] htmlBytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);

            // Return the HTML content as a downloadable HTML file.
            return File(
                htmlBytes,
                "text/html",
                "Output.html");
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
