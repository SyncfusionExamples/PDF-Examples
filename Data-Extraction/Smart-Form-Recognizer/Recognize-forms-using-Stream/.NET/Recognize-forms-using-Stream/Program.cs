using System.IO;
using Syncfusion.SmartFormRecognizer;

namespace RecognizeFormsUsingStream
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
				// Recognize the form and get the output as PDF stream.
				Stream outputStream = smartFormRecognizer.RecognizeFormAsPdfStream(inputStream);
				// Save the output PDF stream to file.
				using (FileStream fileStream = File.Create(Path.GetFullPath(@"Output\Output.pdf")))
				{
					outputStream.Seek(0, SeekOrigin.Begin);
					outputStream.CopyTo(fileStream);
				}
			}
		}
	}
}
