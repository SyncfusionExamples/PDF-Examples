using Create_PDF_AWS_Elastic_Beanstalk.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Drawing;
using System.Diagnostics;

namespace Create_PDF_AWS_Elastic_Beanstalk.Controllers
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
        public IActionResult CreatePDF()
        {
            //Open an existing PDF document.
            FileStream fileStream = new FileStream("Data/Input.pdf", FileMode.Open, FileAccess.Read);
            PdfLoadedDocument document = new PdfLoadedDocument(fileStream);

            //Get the first page from a document.
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to the list.
            List<object> data = new List<object>();
            data.Add(new { Product_ID = "1001", Product_Name = "Bicycle", Price = "10,000" });
            data.Add(new { Product_ID = "1002", Product_Name = "Head Light", Price = "3,000" });
            data.Add(new { Product_ID = "1003", Product_Name = "Break wire", Price = "1,500" });

            //Assign data source.
            pdfGrid.DataSource = data;

            //Apply built-in table style.
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent3);

            //Draw the grid to the page of PDF document.
            pdfGrid.Draw(graphics, new RectangleF(40, 400, page.Size.Width - 80, 0));
            //Create the memory stream.
            MemoryStream stream = new MemoryStream();
            //Save the document to the memory stream.
            document.Save(stream);
	    //Close the documet
	    document.Close(true); 
	    //Return the PDF file as a download
            return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "Output.pdf");
        }
    }
}
