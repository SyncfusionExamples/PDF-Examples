using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Creating_a_PDF_document_with_image.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Creating_a_PDF_document_with_image.Controllers
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

        public IActionResult CreateDocument()
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            string imagePath = _hostingEnvironment.WebRootPath + "/Data/Autumn Leaves.jpg";

            //Get stream from the image file. 
            FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);

            //Load the image from stream. 
            PdfBitmap image = new PdfBitmap(imageStream);

            //Draw the image.
            graphics.DrawImage(image, 0, 0);

            //Create memory stream. 
            MemoryStream stream = new MemoryStream();

            //Save the PDF document to stream.
            document.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;

            //Close the document.
            document.Close(true);

            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";

            //Define the file name.
            string fileName = "Output.pdf";

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
