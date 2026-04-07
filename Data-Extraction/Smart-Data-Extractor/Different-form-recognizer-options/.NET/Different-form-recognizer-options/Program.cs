using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.SmartDataExtractor;
using Syncfusion.SmartFormRecognizer;

namespace DifferentFormRecognizerOptions
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
				// Enable form detection in the document to identify form fields.
				extractor.EnableFormDetection = true;

				// Configure form recognition options for advanced detection.
				FormRecognizeOptions formOptions = new FormRecognizeOptions();
				// Recognize forms across pages 1 to 5 in the document.
				formOptions.PageRange = new int[,] { { 1, 5 } };
				// Set confidence threshold for form recognition to filter results.
				formOptions.ConfidenceThreshold = 0.6;
				// Enable detection of signatures within the document.
				formOptions.DetectSignatures = true;
				// Enable detection of textboxes within the document.
				formOptions.DetectTextboxes = true;
				// Enable detection of checkboxes within the document.
				formOptions.DetectCheckboxes = true;
				// Enable detection of radio buttons within the document.
				formOptions.DetectRadioButtons = true;
				// Assign the configured form recognition options to the extractor.
				extractor.FormRecognizeOptions = formOptions;

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
