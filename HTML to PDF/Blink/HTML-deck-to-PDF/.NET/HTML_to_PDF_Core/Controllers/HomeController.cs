using HTML_to_PDF_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Diagnostics;

namespace HTML_to_PDF_Core.Controllers
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

        public IActionResult ExportToPDF()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR_LICENSE_KEY"); 
            //Initialize HTML to PDF converter
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();

            //Set Blink viewport size
            blinkConverterSettings.ViewPortSize = new Syncfusion.Drawing.Size(1280, 0);
            blinkConverterSettings.MediaType = MediaType.Print;
            blinkConverterSettings.Css = @"@media print {

            body {
                overflow: visible !important;
                height: auto !important;
            }

            .deck-container,
            .slides {
                display: block !important;
                height: auto !important;
                position: static !important;
            }

            .slide {
                position: relative !important;
                top: auto !important;
                left: auto !important;
                opacity: 1 !important;
                visibility: visible !important;
                display: block !important;
                width: 100% !important;
                min-height: 100vh !important;
                page-break-after: always;
                break-after: page;
            }

            .slide-content {
                transform: none !important;
            }

            .controls,
            .keyboard-hint,
            .progress-line-container {
                display: none !important;
            }
        }";
            //Assign Blink converter settings to HTML converter
            htmlConverter.ConverterSettings = blinkConverterSettings;

            string baseUrl = Path.GetFullPath("HtmlDeck");

            string inputHtml = System.IO.File.ReadAllText(Path.Combine(baseUrl, "index1.html")); //use Index.html or index1.html (dec similar to PPT)

            //Convert URL to PDF document
            PdfDocument document = htmlConverter.Convert(inputHtml, baseUrl);

            //Create memory stream
            MemoryStream stream = new MemoryStream();

            //Save the document to memory stream
            document.Save(stream);
            document.Close();

            return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "HTML-to-PDF.pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}