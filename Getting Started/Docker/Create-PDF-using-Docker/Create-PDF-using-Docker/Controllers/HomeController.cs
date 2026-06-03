using Create_PDF_using_Docker.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Diagnostics;

namespace Create_PDF_using_Docker.Controllers
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

        public ActionResult CreatePDF()
        {
            List<WeatherForecastPdfRow> forecasts = GetForecasts();

            // Create a new PDF document.
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                // Add page to the PDF document.
                PdfPage page = pdfDocument.Pages.Add();
                // Create title and description.
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
                PdfTextElement title = new PdfTextElement("Weather Forecast", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement(
                    "This component demonstrates fetching data from a service and exporting the data to a PDF document using Syncfusion .NET PDF library.",
                    contentFont,
                    PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat
                {
                    Layout = PdfLayoutType.Paginate
                };
                result = content.Draw(
                    page,
                    new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height),
                    format);
                // Create and style the PDF grid.
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);
                // Assign data source.
                pdfGrid.DataSource = forecasts;
                pdfGrid.Style.Font = contentFont;
                // Draw PDF grid into the PDF page.
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));
                using (MemoryStream stream = new MemoryStream())
                {
                    // Save the PDF document into the stream.
                    pdfDocument.Save(stream);
                    pdfDocument.Close(true);

                    return File(stream.ToArray(), "application/pdf", "Output.pdf");
                }
            }
        }

        private static List<WeatherForecastPdfRow> GetForecasts()
        {
            string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

            return Enumerable.Range(1, 5)
                .Select(index => new WeatherForecastPdfRow
                {
                    Date = DateTime.UtcNow.AddDays(index).ToString("yyyy-MM-dd"),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                })
                .ToList();
        }

        private sealed class WeatherForecastPdfRow
        {
            public string Date { get; set; } = string.Empty;

            public int TemperatureC { get; set; }

            public string Summary { get; set; } = string.Empty;
        }
    }
}
