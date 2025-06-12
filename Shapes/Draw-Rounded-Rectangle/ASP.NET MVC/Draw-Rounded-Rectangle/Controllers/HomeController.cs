using System.Diagnostics;
using Draw_Rounded_Rectangle.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace Draw_Rounded_Rectangle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public ActionResult CreatePDF()
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a new page to the document
            PdfPage page = document.Pages.Add();

            //Initialize graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Represent the shape
            graphics.DrawString("Rounded Rectangle", new PdfStandardFont(PdfFontFamily.Helvetica, 16), PdfBrushes.DarkBlue, new PointF(190, 30));

            //Create the rectangle
            RectangleF rect = new RectangleF(160, 70, 200, 100);
            int dimension = 30;

            //Create the PdfPath
            PdfPath pdfPath = new PdfPath();

            //Draw the rounded rectangle as separate 4 arcs with same dimensions of width and height
            pdfPath.AddArc(rect.X, rect.Y, dimension, dimension, 180, 90);
            pdfPath.AddArc(rect.X + rect.Width - dimension, rect.Y, dimension, dimension, 270, 90);
            pdfPath.AddArc(rect.X + rect.Width - dimension, rect.Y + rect.Height - dimension, dimension, dimension, 0, 90);
            pdfPath.AddArc(rect.X, rect.Y + rect.Height - dimension, dimension, dimension, 90, 90);

            //Close the path
            pdfPath.CloseFigure();

            //Draw the PDF path
            graphics.DrawPath(PdfPens.Black, pdfPath);

            //Create memory stream
            MemoryStream stream = new MemoryStream();

            //Save the document to memory stream
            document.Save(stream);

            return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "Output.pdf");
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
    }
}
