using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.SmartDataExtractor;

namespace FormDetection
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
				// Enable or disable form detection in the document to identify form fields.
				// By default this property is true.
				extractor.EnableFormDetection = false;
				// Extract form data and return as a loaded PDF document.
				PdfLoadedDocument document = extractor.ExtractDataAsPdfDocument(stream);
				// Save the extracted output as a new PDF file.
				document.Save(Path.GetFullPath(@"Output\Output.pdf"));
				// Close the document to release resources.
				document.Close(true);
			}
		}
	}
}
