using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.SmartFormRecognizer;

namespace RecognizeFormsUsingPdf
{
	class Program
	{
		static void Main(string[] args)
		{	
			// Read the input PDF file as stream.
			using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
			{
				// Initialize the Form Recognizer.
				FormRecognizer smartFormRecognizer = new FormRecognizer();
				// Recognize the form and get the output as PDF document.
				PdfLoadedDocument pdfLoadedDocument = smartFormRecognizer.RecognizeFormAsPdfDocument(inputStream);
				// Save the loaded document.
				pdfLoadedDocument.Save(Path.GetFullPath(@"Output\Output.pdf"));
				// Close the document to release resources.
				pdfLoadedDocument.Close(true);
			}
		}
	}
}
