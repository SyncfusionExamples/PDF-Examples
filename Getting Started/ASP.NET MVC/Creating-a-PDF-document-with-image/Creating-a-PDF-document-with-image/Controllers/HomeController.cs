using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Creating_a_PDF_document_with_image.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateDocument()
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Load the image from the disk.
            PdfBitmap image = new PdfBitmap(Server.MapPath("~/App_Data/Autumn Leaves.jpg"));

            //Draw the image.
            graphics.DrawImage(image, 0, 0);

            //Open the document in browser after saving it
            document.Save("Output.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save);

            //Close the document.
            document.Close(true);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}