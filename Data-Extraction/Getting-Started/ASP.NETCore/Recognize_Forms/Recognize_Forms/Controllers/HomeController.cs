using Microsoft.AspNetCore.Mvc;
using Recognize_Forms.Models;
using System.Diagnostics;
using Syncfusion.SmartFormRecognizer;
using System.Text;

namespace Recognize_Forms.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ExtractForms()

        {

            // Read the input PDF file as stream.
            using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
            {

                // Initialize the Form Recognizer.        
                FormRecognizer smartFormRecognizer = new FormRecognizer();

                // Recognize the form and get the output as JSON string.
                string outputJson = smartFormRecognizer.RecognizeFormAsJson(inputStream);

                // Convert JSON string into a MemoryStream for download.        
                MemoryStream outputStream = new MemoryStream(Encoding.UTF8.GetBytes(outputJson));

                // Reset stream position.
                outputStream.Position = 0;

                // Return JSON file as download in browser.        
                FileStreamResult fileStreamResult = new FileStreamResult(outputStream, "application/json");

                fileStreamResult.FileDownloadName = "Output.json";

                return fileStreamResult;

            }

        }
    }
}
