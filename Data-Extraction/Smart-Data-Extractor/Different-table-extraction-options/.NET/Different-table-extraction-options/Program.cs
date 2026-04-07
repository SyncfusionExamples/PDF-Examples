using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.SmartDataExtractor;
using Syncfusion.SmartTableExtractor;

namespace DifferentTableExtractionOptions
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
				// Enable table detection and set confidence threshold.
				extractor.EnableTableDetection = true;

				// Configure table extraction options.
				TableExtractionOptions tableOptions = new TableExtractionOptions();
				// Extract tables across pages 1 to 5.
				tableOptions.PageRange = new int[,] { { 1, 5 } };
				// Set confidence threshold for table extraction.
				tableOptions.ConfidenceThreshold = 0.6;
				// Enable detection of borderless tables.
				tableOptions.DetectBorderlessTables = true;
				// Assign the table extraction options to the extractor.
				extractor.TableExtractionOptions = tableOptions;

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
