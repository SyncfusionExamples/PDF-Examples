using Syncfusion.Pdf.Parsing;
using Syncfusion.SmartFormRecognizer;

namespace RecognizeFormsUsingPdfAsync
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// Read the input PDF file as stream.
			using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
			{
				// Initialize the Form Recognizer.
				FormRecognizer smartFormRecognizer = new FormRecognizer();
				// Recognize the form and get the output as PDF document asynchronously.
				PdfLoadedDocument pdfLoadedDocument = await smartFormRecognizer.RecognizeFormAsPdfDocumentAsync(inputStream);
				// Save the loaded document.
				pdfLoadedDocument.Save(Path.GetFullPath(@"Output\Output.pdf"));
				// Close the document to release resources.
				pdfLoadedDocument.Close(true);
			}
		}
	}
}
