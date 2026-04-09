using Extract_Data.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.SmartDataExtractor;
using System.Diagnostics;
using System.Text;

namespace Extract_Data.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
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
		public IActionResult ExtractData()
		{
			// Open the input PDF file as a stream.
			using (FileStream stream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.Read))
			{
				// Initialize the Smart Data Extractor.
				DataExtractor extractor = new DataExtractor();
				// Extract form data as JSON.
				string data = extractor.ExtractDataAsJson(stream);
				// Convert JSON string into a MemoryStream for download.
				MemoryStream outputStream = new MemoryStream(Encoding.UTF8.GetBytes(data));
				// Reset stream position.
				outputStream.Position = 0;
				// Return JSON file as download in browser.
				FileStreamResult fileStreamResult = new FileStreamResult(outputStream, "application/json");
				fileStreamResult.FileDownloadName = "Output.json";
				return fileStreamResult;
			}
		}
	}
}
