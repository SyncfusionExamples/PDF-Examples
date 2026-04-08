using System.IO;
using System.Threading.Tasks;
using Syncfusion.SmartFormRecognizer;

namespace RecognizeFormsUsingJsonAsync
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
				// Recognize the form and get the output as JSON string asynchronously.
				string outputJson = await smartFormRecognizer.RecognizeFormAsJsonAsync(inputStream);
				// Save the output JSON to file.
				File.WriteAllText(Path.GetFullPath(@"Output\Output.json"), outputJson);
			}
		}
	}
}
