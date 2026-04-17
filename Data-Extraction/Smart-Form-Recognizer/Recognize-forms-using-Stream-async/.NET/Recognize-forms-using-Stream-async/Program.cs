using System.IO;
using System.Threading.Tasks;
using Syncfusion.SmartFormRecognizer;

namespace RecognizeFormsUsingStreamAsync
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
				// Recognize the form and get the output as PDF stream asynchronously.
				Stream outputStream = await smartFormRecognizer.RecognizeFormAsPdfStreamAsync(inputStream);
				// Save the output PDF stream to file.
				using (FileStream fileStream = File.Create(Path.GetFullPath(@"Output\Output.pdf")))
				{
					outputStream.Seek(0, SeekOrigin.Begin);
					await outputStream.CopyToAsync(fileStream);
				}
			}
		}
	}
}
