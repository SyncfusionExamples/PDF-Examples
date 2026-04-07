using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.SmartDataExtractor;

namespace DisableTableDetection
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
				// Enable or disable table detection and set confidence threshold.
				// By default this property is true.
				extractor.EnableTableDetection = false;
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
