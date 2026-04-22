using System.Text;
using Syncfusion.SmartDataExtractor;

namespace ExtractDataAsJsonFromImage
{
	class Program
	{
		static void Main(string[] args)
		{
			// Open the input image file as a stream.
			using (FileStream stream = new FileStream(Path.GetFullPath(@"Data\Input.png"), FileMode.Open, FileAccess.ReadWrite))
			{
				// Initialize the Data Extractor.
				DataExtractor extractor = new DataExtractor();
				// Extract data as JSON from the image stream.
				string data = extractor.ExtractDataAsJson(stream);
				// Save the extracted JSON data into an output file.
				File.WriteAllText(Path.GetFullPath(@"Output\Output.json"), data, Encoding.UTF8);
			}
		}
	}
}
