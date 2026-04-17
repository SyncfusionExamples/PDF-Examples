using Syncfusion.SmartFormRecognizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Recognize_Forms.Controllers
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

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult RecognizeForm()
		{
			// Resolve the path to the input PDF file inside the App_Data folder.
			string inputPath = Server.MapPath("~/App_Data/Input.pdf");

			// Open the input PDF file as a stream.
			using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.ReadWrite))
			{
				// Initialize the Smart Form Recognizer.
				FormRecognizer smartFormRecognizer = new FormRecognizer();

				// Recognize the form and get the output as JSON string.
				string outputJson = smartFormRecognizer.RecognizeFormAsJson(inputStream);

				// Convert JSON string into a MemoryStream for download.
				MemoryStream outputStream = new MemoryStream(Encoding.UTF8.GetBytes(outputJson));
				outputStream.Position = 0;

				// Return JSON file as download in browser.
				return File(outputStream, "application/json", "Output.json");
			}
		}

	}
}