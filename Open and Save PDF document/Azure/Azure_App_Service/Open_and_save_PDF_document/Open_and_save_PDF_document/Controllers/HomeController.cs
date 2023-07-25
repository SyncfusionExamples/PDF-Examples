using Microsoft.AspNetCore.Mvc;
using Open_and_save_PDF_document.Models;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Diagnostics;

namespace Open_and_save_PDF_document.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OpenAndSavePDFDocument()
        {
            //Load PDF document as stream.
            string docPath = Path.Combine(_hostingEnvironment.WebRootPath + "/Data/Input.pdf");
            FileStream docStream = new FileStream(docPath, FileMode.Open, FileAccess.Read);
            //Load an existing PDF document.
            PdfLoadedDocument document = new PdfLoadedDocument(docStream);
            //Load the existing page.
            PdfLoadedPage loadedPage = document.Pages[0] as PdfLoadedPage;
            //Create PDF graphics for the page.
            PdfGraphics graphics = loadedPage.Graphics;

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to the list.
            List<object> data = new List<object>();
            Object row1 = new { Product_ID = "1001", Product_Name = "Bicycle", Price = "10,000" };
            Object row2 = new { Product_ID = "1002", Product_Name = "Head Light", Price = "3,000" };
            Object row3 = new { Product_ID = "1003", Product_Name = "Break wire", Price = "1,500" };
            data.Add(row1);
            data.Add(row2);
            data.Add(row3);
            //Add list to IEnumerable.
            IEnumerable<object> dataTable = data;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Apply built-in table style.
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent3);
            //Draw the grid to the page of PDF document.
            pdfGrid.Draw(graphics, new RectangleF(40, 400, loadedPage.Size.Width - 80, 0));

            //Saving the PDF to the MemoryStream.
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            //Set the position as '0'.
            stream.Position = 0;
            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "Sample.pdf";
            return fileStreamResult;
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