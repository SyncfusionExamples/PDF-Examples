using System.IO;
using System.Text;
using Syncfusion.SmartDataExtractor;

namespace ExtractDataAsJsonFromPdfDocument
{
	class Program
	{
		static void Main(string[] args)
		{
			// Open the input PDF file as a stream.
			using (FileStream stream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
			{
				// Initialize the Smart Data Extractor.
				DataExtractor extractor = new DataExtractor();
				// Extract form data as JSON.
				string data = extractor.ExtractDataAsJson(stream);
				// Save the extracted JSON data into an output file.
				File.WriteAllText(Path.GetFullPath(@"Output\Output.json"), data, Encoding.UTF8);
			}
		}
	}
}
