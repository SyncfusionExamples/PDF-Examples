using System.IO;
using System.Text;
using Syncfusion.SmartTableExtractor;

namespace ApplyConfidenceThresholdToTableData
{
	class Program
	{
		static void Main(string[] args)
		{
			// Open the input PDF file as a stream.
			using (FileStream stream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.Read))
			{
				// Initialize the Smart Table Extractor.
				TableExtractor extractor = new TableExtractor();
				// Configure table extraction options to set the confidence threshold for detection.
				TableExtractionOptions options = new TableExtractionOptions();
				options.ConfidenceThreshold = 0.75;
				// Assign the configured options to the extractor.
				extractor.TableExtractionOptions = options;
				// Extract table data from the PDF document as a JSON string.
				string data = extractor.ExtractTableAsJson(stream);
				// Save the extracted JSON data into an output file.
				File.WriteAllText(Path.GetFullPath(@"Output\Output.json"), data, Encoding.UTF8);
			}
		}
	}
}
