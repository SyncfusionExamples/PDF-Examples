using System.IO;
using System.Text;
using Syncfusion.SmartTableExtractor;

//Open the input PDF file as a stream.
using (FileStream stream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
{
	// Initialize the Smart Table Extractor
	TableExtractor extractor = new TableExtractor();
	//Extract table data from the PDF document as markdown.
	string data = extractor.ExtractTableAsMarkdown(stream);
	//Save the extracted markdown data into an output file.
	File.WriteAllText(Path.GetFullPath(@"Output\Output.md"), data, Encoding.UTF8);
}