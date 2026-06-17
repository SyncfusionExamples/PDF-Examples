using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace Web_API_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PdfController> _logger;

        public PdfController(ILogger<PdfController> logger)
        {
            _logger = logger;
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
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();

            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;
                PdfPage page = pdfDocument.Pages.Add();
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
                PdfTextElement title = new PdfTextElement("Weather Forecast", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));
                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("This component demonstrates fetching data from a service and exporting the data to a PDF document using Syncfusion .NET PDF library.", contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat
                {
                    Layout = PdfLayoutType.Paginate
                };
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);
                pdfGrid.DataSource = forecasts;
                pdfGrid.Style.Font = contentFont;
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    pdfDocument.Save(stream);
                    return new MemoryStream(stream.ToArray());
                }
            }
        }
    }
}
