using Microsoft.AspNetCore.Mvc;
using Perform_OCR_NET_Core.Models;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.Diagnostics;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Perform_OCR_NET_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
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
            //Load PDF document as stream
            string docPath = _hostingEnvironment.WebRootPath + "/Data/Input.pdf";
            FileStream docStream = new FileStream(docPath, FileMode.Open, FileAccess.Read);

            //Load the PDF document 
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            string tesseractPath = _hostingEnvironment.WebRootPath + "/Data/Tesseractbinaries/Windows";

            //Initialize the OCR processor by providing the path of tesseract binaries
            using (OCRProcessor processor = new OCRProcessor(tesseractPath))
            {
                //Language to process the OCR
                processor.Settings.Language = Languages.English;

                string tessdataPath = _hostingEnvironment.WebRootPath + "/Data/tessdata/";
                //Process OCR by providing loaded PDF document, Data dictionary and language
                processor.PerformOCR(loadedDocument, tessdataPath);
            }

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();
            loadedDocument.Save(stream);

            //Close the PDF document 
            loadedDocument.Close(true);

            //Set the position as '0'
            stream.Position = 0;

            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

            fileStreamResult.FileDownloadName = "OCR.pdf";

            return fileStreamResult;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}