using System.Diagnostics;
using DifferentFormatsImageintoPDF.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

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

                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    //Add a page to the document
                    PdfPage page = doc.Pages.Add();

                    //Create PDF graphics for the page
                    PdfGraphics graphics = page.Graphics;

                    //Load the image from the disk
                    FileStream imageStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    PdfBitmap image = new PdfBitmap(imageStream);

                    //Draw the image
                    graphics.DrawImage(image, new PointF(0, 0), new SizeF(400, 600));
                }

                else if (extension == ".tiff" || extension == ".tif" || extension == ".bmp" || extension == ".gif")
                {
                    //Add a page to the document
                    PdfPage page = doc.Pages.Add();

                    //Create PDF graphics for the page
                    PdfGraphics graphics = page.Graphics;

                    //Load the TIFF image
                    FileStream imageStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    PdfTiffImage image = new PdfTiffImage(imageStream);

                    //Draw the image
                    graphics.DrawImage(image, new PointF(0, 0), new SizeF(400, 600));
                }
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
