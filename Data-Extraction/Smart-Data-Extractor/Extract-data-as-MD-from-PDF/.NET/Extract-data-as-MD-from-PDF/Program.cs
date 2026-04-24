using Syncfusion.SmartDataExtractor;
using System.Text;

//Open the input PDF file as a stream.
using (FileStream stream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
{
	//Initialize the Smart Data Extractor.
	DataExtractor extractor = new DataExtractor();
	//Extract data as Markdown.
	string data = extractor.ExtractDataAsMarkdown(stream);
	//Save the extracted Markdown data into an output file.
	File.WriteAllText(Path.GetFullPath(@"Output\Output.md"), data, Encoding.UTF8);
}
