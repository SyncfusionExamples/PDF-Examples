using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merge_multiple_PDF_documents_from_disk.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MergePDF()
        {
            //Creates the new PDF document.
            PdfDocument finalDoc = new PdfDocument();

            //Creates a string array of source files to be merged.
            string[] source = System.IO.Directory.GetFiles(Server.MapPath("~/App_Data/"), "*.pdf");

            //Merges PDFDocument.
            PdfDocument.Merge(finalDoc, source);

            //Open the document in browser after saving it.
            finalDoc.Save("Output.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save);

            //Closes the document
            finalDoc.Close(true);

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