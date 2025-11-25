using System.Diagnostics;
using Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

namespace Layer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CreateLayer()
        {
            PdfDocument document = new PdfDocument();

            document.PageSettings.Margins.All = 0;

            PdfPage page = document.Pages.Add();

            PdfPageLayer backgroundLayer = page.Layers.Add("Background");

            PdfBrush backgroundBrush = new PdfSolidBrush(Color.LightBlue);
            backgroundLayer.Graphics.DrawRectangle(backgroundBrush, new RectangleF(0, 0, page.Size.Width, page.Size.Height));

            PdfPageLayer mainContentLayer = page.Layers.Add("Main Content");

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
            PdfBrush textBrush = new PdfSolidBrush(Color.Black);
            mainContentLayer.Graphics.DrawString("Welcome to PDF Layers!", font, textBrush, new PointF(50, 50));

            MemoryStream outputStream = new MemoryStream();

            document.Save(outputStream);

            outputStream.Position = 0;

            document.Close(true);

            return File(outputStream, "application/pdf", "Layer.pdf");
        }

        public IActionResult AddLayerToDocument()
        {
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("Data/input.pdf");

            loadedDocument.FindText("PDF Succinctly", 0, out var matchRect);

            PdfLayer? parentLayer = null;

            if (matchRect != null && matchRect.Count > 0)
            {
                parentLayer = AddLayer(loadedDocument, "PDF Succinctly", matchRect[0], PdfBrushes.Red, null);

                var childTexts = new[]
                {
                    new { Text = "Introduction", Brush = PdfBrushes.Green },
                    new { Text = "The PDF Standard", Brush = PdfBrushes.Blue },
                };

                foreach (var item in childTexts)
                {
                    loadedDocument.FindText(item.Text, 0, out var childRect);
                    if (childRect != null && childRect.Count > 0)
                    {
                        AddLayer(loadedDocument, item.Text, childRect[0], item.Brush, parentLayer);
                    }
                }
            }

            return ExportPDFFile(loadedDocument, "Output.pdf");
        }

        public IActionResult SetLayerVisibility()
        {
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("Data/layer.pdf");

            PdfLayer layer = loadedDocument.Layers[0];

            layer.Visible = false;

            return ExportPDFFile(loadedDocument, "LayerVisibility.pdf");
        }

        public IActionResult RemoveLayer()
        {
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("Data/layer.pdf");

            PdfLoadedPage? loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

            PdfPageLayerCollection layers = loadedPage!.Layers;

            layers.RemoveAt(0);

            return ExportPDFFile(loadedDocument, "RemoveLayer.pdf");
        }


        private FileStreamResult ExportPDFFile(PdfLoadedDocument document, string fileName)
        {
            // Save the given document into a memory stream
            MemoryStream outputStream = new MemoryStream();
            document.Save(outputStream);

            // Reset stream to the beginning for correct file delivery
            outputStream.Position = 0;

            // Close the document and release resources
            document.Close(true);

            // Return the memory stream as a downloadable PDF file
            return File(outputStream, "application/pdf", fileName);
        }


        /// <summary>
        /// Adds a layer to the PDF document at the specified location.
        /// </summary>
        /// <param name="loadedDocument">The loaded PDF document.</param>
        /// <param name="layerName">Name of the layer.</param>
        /// <param name="rect">Rectangle area to draw.</param>
        /// <param name="brush">Brush color for drawing.</param>
        /// <param name="parentLayer">Optional parent layer for nesting.</param>
        /// <returns>The created PdfLayer.</returns>
        PdfLayer AddLayer(PdfLoadedDocument loadedDocument, string layerName, RectangleF rect, PdfBrush brush, PdfLayer? parentLayer)
        {
            // Create a new layer, nested if parentLayer is provided
            PdfLayer layer = parentLayer == null
                ? loadedDocument.Layers.Add(layerName)
                : parentLayer.Layers.Add(layerName);

            // Create graphics for the layer on the first page
            PdfGraphics graphics = layer.CreateGraphics(loadedDocument.Pages[0]!);

            // Apply transparency and draw the rectangle
            graphics.Save();
            graphics.SetTransparency(0.5f);
            graphics.DrawRectangle(brush, rect);
            graphics.Restore();

            return layer;
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
