using System.Diagnostics;
using DifferentFormatsImageintoPDF.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using SkiaSharp;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DifferentFormatsImageintoPDF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _webHostEnvironment;

        public HomeController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult DifferentFormatsImagetoPDF()
        {
            //Create a new PDF document
            PdfDocument doc = new PdfDocument();

            string[] files = Directory.GetFiles(_webHostEnvironment.WebRootPath + "/Data/");

            foreach (var file in files)
            {
                string extension = Path.GetExtension(file);
                //Load the image from the disk
                FileStream imageStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                PdfImage image;
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    image = new PdfBitmap(imageStream);
                }
                else
                {
                    image = new PdfTiffImage(imageStream);
                }

                //Add section
                PdfSection section = doc.Sections.Add();
                //Set margin
                section.PageSettings.Margins.All = 0;
                //Set page size as image size.
                section.PageSettings.Size = new SizeF(image.Width, image.Height);
                //Add page to the section and initialize graphics for the page
                PdfPage page = section.Pages.Add();
                //Create PDF graphics for the page
                PdfGraphics graphics = page.Graphics;
                graphics.DrawImage(image, new PointF(0, 0), new SizeF(image.Width, image.Height));
            }

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "Sample.pdf";
            return fileStreamResult;
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
