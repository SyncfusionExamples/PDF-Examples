using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Merge_multiple_PDF_documents.Models;
using Syncfusion.Pdf;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Merge_multiple_PDF_documents.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult MergePDF()
        {
            //Generate a PDF document
            PdfDocument finalDoc = new PdfDocument();

            //Get stream from the PDF documents. 
            FileStream stream1 = new FileStream(_hostingEnvironment.WebRootPath + "/Data/file1.pdf", FileMode.Open, FileAccess.Read);
            FileStream stream2 = new FileStream(_hostingEnvironment.WebRootPath + "/Data/file2.pdf", FileMode.Open, FileAccess.Read);

            //Creates a PDF stream for merging.
            Stream[] streams = { stream1, stream2 };

            //Merges PDFDocument.
            PdfDocumentBase.Merge(finalDoc, streams);

            //Save the PDF document to stream
            MemoryStream stream = new MemoryStream();
            finalDoc.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;

            //Close the document.
            finalDoc.Close(true);

            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";

            //Define the file name.
            string fileName = "Sample.pdf";

            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
