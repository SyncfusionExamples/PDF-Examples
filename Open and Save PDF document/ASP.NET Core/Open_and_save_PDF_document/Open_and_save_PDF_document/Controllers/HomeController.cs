using Microsoft.AspNetCore.Mvc;
using Open_and_save_PDF_document.Models;
using System.Diagnostics;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;

namespace Open_and_save_PDF_document.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public HomeController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OpenAndSaveDocument()
        {
            //Load PDF document as stream
            string docPath = _hostingEnvironment.WebRootPath + "/Data/Input.pdf";
            FileStream docStream = new FileStream(docPath, FileMode.Open, FileAccess.Read);
            //Load an existing PDF document
            PdfLoadedDocument document = new PdfLoadedDocument(docStream);
            //Load the existing page
            PdfLoadedPage loadedPage = document.Pages[0] as PdfLoadedPage;
            //Create PDF graphics for the page
            PdfGraphics graphics = loadedPage.Graphics;

            //Create a PdfGrid
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to the list
            List<object> data = new List<object>();
            Object row1 = new { Product_ID = "1001", Product_Name = "Bicycle", Price = "10,000" };
            Object row2 = new { Product_ID = "1002", Product_Name = "Head Light", Price = "3,000" };
            Object row3 = new { Product_ID = "1003", Product_Name = "Break wire", Price = "1,500" };
            data.Add(row1);
            data.Add(row2);
            data.Add(row3);
            //Add list to IEnumerable
            IEnumerable<object> dataTable = data;
            //Assign data source
            pdfGrid.DataSource = dataTable;
            //Apply built-in table style
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent3);
            //Draw the grid to the page of PDF document
            pdfGrid.Draw(graphics, new RectangleF(40, 400, loadedPage.Size.Width - 80, 0));
            
            //Create memory stream
            MemoryStream stream = new MemoryStream();
            //Save the PDF document to stream
            document.Save(stream);
            //If the position is not set to '0' then the PDF will be empty
            stream.Position = 0;
            //Close the document.
            document.Close(true);
            //Defining the content type for PDF file
            string contentType = "application/pdf";
            //Define the file name
            string fileName = "Sample.pdf";
            //Creates a FileContentResult object by using the file contents, content type, and file name
            return File(stream, contentType, fileName);
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