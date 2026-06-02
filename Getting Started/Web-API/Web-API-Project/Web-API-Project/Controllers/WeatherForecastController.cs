using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace Web_API_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/api/Pdf")]
        public IActionResult CreatePdfDocument()
        {
            try
            {
                const string fileDownloadName = "Output.pdf";
                const string contentType = "application/pdf";
                var stream = ExportWeatherForecastToPdf();
                stream.Position = 0;
                return File(stream, contentType, fileDownloadName);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error occurred while creating PDF file: {ex.Message}");
            }
        }

        private MemoryStream ExportWeatherForecastToPdf()
        {
            var forecasts = Get().ToList();

            //Create a new PDF document.
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document.
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font.
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page.
                PdfTextElement title = new PdfTextElement("Weather Forecast", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("This component demonstrates fetching data from a service and exporting the data to a PDF document using Syncfusion .NET PDF library.", contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat
                {
                    Layout = PdfLayoutType.Paginate
                };

                //Draw a text to the PDF document.
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid.
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

                //Assign data source.
                pdfGrid.DataSource = forecasts;
                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page.
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream.
                    pdfDocument.Save(stream);

                    //Closing the PDF document.
                    pdfDocument.Close(true);

                    return new MemoryStream(stream.ToArray());
                }
            }
        }
    }
}
