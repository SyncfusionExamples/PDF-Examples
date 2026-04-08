using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Syncfusion.SmartTableExtractor;

namespace ExtractTableDataAsync
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// Open the input PDF file as a stream.
			using (FileStream stream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.Read))
			{
				// Initialize the Smart Table Extractor and assign the configured options.
				TableExtractor tableExtractor = new TableExtractor();
				// Create a cancellation token with a timeout of 30 seconds to control the async operation.
				using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
				// Call the asynchronous extraction API to extract table data as a JSON string.
				string data = await tableExtractor.ExtractTableAsJsonAsync(stream, cts.Token);
				// Save the extracted JSON data into an output file.
				File.WriteAllText(Path.GetFullPath(@"Output\Output.json"), data, Encoding.UTF8);
			}
		}
	}
}
