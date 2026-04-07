using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.SmartDataExtractor;

namespace ApplyConfidenceThresholdToExtractData
{
	class Program
	{
		static void Main(string[] args)
		{
			// Load the input PDF file.
			using (FileStream stream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
			{
				// Initialize the Smart Data Extractor.
				DataExtractor extractor = new DataExtractor();
				// Apply confidence threshold to extract the data.
				// Default confidence threshold value is 0.6.
				extractor.ConfidenceThreshold = 0.75;

				// Extract data and return as a loaded PDF document.
				PdfLoadedDocument document = extractor.ExtractDataAsPdfDocument(stream);
				// Save the extracted output as a new PDF file.
				document.Save(Path.GetFullPath(@"Output\Output.pdf"));
				// Close the document to release resources.
				document.Close(true);
			}
		}
	}
}
