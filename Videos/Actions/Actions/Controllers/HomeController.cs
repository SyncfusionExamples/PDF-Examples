using System.Diagnostics;
using Actions.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

namespace Actions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult AddUriAction()
        {
            FileStream fileStream = new FileStream("Data\\input.pdf", FileMode.Open, FileAccess.Read);

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream);

            PdfPageBase page = loadedDocument.Pages[1];

            List<RectangleF> matchedItems;

            loadedDocument.FindText("PDF Succinctly", 1, out matchedItems);

            PdfUriAction uriAction = new PdfUriAction("https://www.syncfusion.com/document-sdk/net-pdf-library");

            PdfActionAnnotation actionAnnotation = new PdfActionAnnotation(matchedItems[0], uriAction);

            page.Annotations.Add(actionAnnotation);

            return CreateFileResult(loadedDocument, "Output.pdf");
        }

        public IActionResult AddGoToAction()
        {
            FileStream fileStream = new FileStream("Data\\input.pdf", FileMode.Open, FileAccess.Read);

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream);

            PdfPageBase page = loadedDocument.Pages[2];

            List<RectangleF> matchedItems;

            loadedDocument.FindText("PDF Succinctly", 2, out matchedItems);

            PdfDestination destination = new PdfDestination(loadedDocument.Pages[4]);

            PdfGoToAction gotoAction = new PdfGoToAction(destination);

            PdfActionAnnotation gotoAnnotation = new PdfActionAnnotation(matchedItems[0], gotoAction);

            page.Annotations.Add(gotoAnnotation);

            return CreateFileResult(loadedDocument, "GoToAction.pdf");
        }

        public IActionResult AddNamedAction()
        {
            FileStream fileStream = new FileStream("Data\\input.pdf", FileMode.Open, FileAccess.Read);

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream);

            PdfPageBase page = loadedDocument.Pages[1];

            List<RectangleF> matchedItems;

            loadedDocument.FindText("PDF Succinctly", 1, out matchedItems);

            PdfNamedAction namedAction = new PdfNamedAction(PdfActionDestination.LastPage);

            PdfActionAnnotation actionAnnotation = new PdfActionAnnotation(matchedItems[0], namedAction);

            page.Annotations.Add(actionAnnotation);

            return CreateFileResult(loadedDocument, "NamedAction.pdf");
        }

        public IActionResult AddLaunchAction()
        {
            FileStream fileStream = new FileStream("Data\\input.pdf", FileMode.Open, FileAccess.Read);

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream);

            PdfPageBase page = loadedDocument.Pages[1];

            List<RectangleF> matchedItems;

            loadedDocument.FindText("PDF Succinctly", 1, out matchedItems);

            PdfLaunchAction launchAction = new PdfLaunchAction("C:\\Users\\Downloads\\input.txt");

            PdfActionAnnotation actionAnnotation = new PdfActionAnnotation(matchedItems[0], launchAction);

            page.Annotations.Add(actionAnnotation);

            return CreateFileResult(loadedDocument, "LaunchAction.pdf");
        }

        private FileStreamResult CreateFileResult(PdfLoadedDocument document, string fileName)
        {
            MemoryStream outputStream = new MemoryStream();
            document.Save(outputStream);
            outputStream.Position = 0;
            document.Close(true);
            return File(outputStream, "application/pdf", fileName);
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
