using System.IO;
using Syncfusion.SmartDataExtractor;

namespace ExtractDataAsStream
{
	class Program
	{
		static void Main(string[] args)
		{
			// Open the input PDF file as a stream.
			using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
			{
				// Initialize the Smart Data Extractor.
				DataExtractor extractor = new DataExtractor();
				// Extract data and return as a PDF stream.
				Stream pdfStream = extractor.ExtractDataAsPdfStream(inputStream);
				// Save the extracted PDF stream into an output file.
				using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output\Output.pdf"), FileMode.Create, FileAccess.Write))
				{
					pdfStream.CopyTo(outputStream);
				}
			}
		}
	}
}
