using System.IO;
using Syncfusion.SmartFormRecognizer;

namespace RecognizeFormsUsingJson
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
				// Recognize the form and get the output as JSON string.
				string outputJson = smartFormRecognizer.RecognizeFormAsJson(inputStream);
				// Save the output JSON to file.
				File.WriteAllText(Path.GetFullPath(@"Output\Output.json"),outputJson);
			}
		}
	}
}
