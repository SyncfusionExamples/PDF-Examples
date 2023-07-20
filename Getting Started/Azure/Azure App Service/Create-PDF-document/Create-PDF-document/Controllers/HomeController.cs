using Create_PDF_document.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using System.Diagnostics;
using Syncfusion.Drawing;

namespace Create_PDF_document.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult CreatePDFDocument()
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            // Set the page size.
            document.PageSettings.Size = PdfPageSize.A4;
            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Load the image from the disk.
            string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "Data/AdventureCycle.jpg");
            FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw an image.
            graphics.DrawImage(image, new RectangleF(130, 0, 250, 100));

            //Draw header text. 
            graphics.DrawString("Adventure Works Cycles", new PdfStandardFont(PdfFontFamily.TimesRoman, 20, PdfFontStyle.Bold), PdfBrushes.Gray, new PointF(150, 150));

            //Add paragraph. 
            string text = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";
            //Create a text element with the text and font.
            PdfTextElement textElement = new PdfTextElement(text, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            //Draw the text in the first column.
            textElement.Draw(page, new RectangleF(0, 200, page.GetClientSize().Width, page.GetClientSize().Height));

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
            pdfGrid.Draw(graphics, new RectangleF(0, 300, page.Size.Width - 80, 0));

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