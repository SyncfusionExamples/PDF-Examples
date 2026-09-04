using System.Text;
using Syncfusion.SmartDataExtractor;

//Open the input PDF file as a stream.
using (FileStream stream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
	//Initialize the Data Extractor.
	DataExtractor extractor = new DataExtractor();
	//Extract data as JSON.
	string data = extractor.ExtractDataAsJson(stream);
	//Save the extracted JSON data into an output file.
	File.WriteAllText(Path.GetFullPath(@"Output/Output.pdf"), data, Encoding.UTF8);
}