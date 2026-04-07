
using Syncfusion.Pdf.Parsing;
using Syncfusion.SmartDataExtractor;

namespace ExtractDataFromPDFDocument
{
	class Program
	{
		static void Main(string[] args)
		{
			//Open the input PDF file as a stream.
			using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open,FileAccess.ReadWrite))
			{
				//Initialize the Smart Data Extractor.
				DataExtractor extractor = new DataExtractor();
				//Extract data and return as a loaded PDF document.
				PdfLoadedDocument document = extractor.ExtractDataAsPdfDocument(inputStream);
				//Save the extracted output as a new PDF file inside the Output folder.
				document.Save(Path.GetFullPath(@"Output/Output.pdf"));
				//Close the document to release resources.
				document.Close(true);
			}
		}
	}
}