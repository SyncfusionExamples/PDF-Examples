using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDF_generation_through_ASMX_based_web_app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TestPdfService()
        {
            Services.PdfService pdfService = new Services.PdfService();

            // Call the method with test data
            byte[] pdf = pdfService.GenerateDocument(
                "EMP001", "John Doe");

            // Return as PDF file
            return File(pdf, "application/pdf", "TestLeaveForm.pdf");
        }
    }
}