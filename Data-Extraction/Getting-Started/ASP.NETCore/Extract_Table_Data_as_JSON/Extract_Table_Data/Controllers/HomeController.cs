using Extract_Table_Data.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.SmartTableExtractor;
using System.Diagnostics;
using System.Text;

namespace Extract_Table_Data.Controllers
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

		public IActionResult ExtractTables()
		{
			// Open the input PDF file as a stream.
			using (FileStream stream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
			{
				// Initialize the Smart Table Extractor.
				TableExtractor extractor = new TableExtractor();
				// Extract table data from the PDF document as JSON string.
				string data = extractor.ExtractTableAsJson(stream);
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
