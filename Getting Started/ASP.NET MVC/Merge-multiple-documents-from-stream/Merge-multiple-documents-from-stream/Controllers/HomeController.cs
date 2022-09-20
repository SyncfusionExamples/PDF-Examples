using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merge_multiple_documents_from_stream.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MergePDFDocuments()
        {
            //Creates the destination document.
            PdfDocument finalDoc = new PdfDocument();

            //Get stream from the PDF documents. 
            Stream stream1 = System.IO.File.OpenRead(Server.MapPath("~/App_Data/File1.pdf"));
            Stream stream2 = System.IO.File.OpenRead(Server.MapPath("~/App_Data/File2.pdf"));

            //Creates a PDF stream for merging.
            Stream[] streams = { stream1, stream2 };

            //Merges PDFDocument.
            PdfDocumentBase.Merge(finalDoc, streams);

            //Open the document in browser after saving it
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