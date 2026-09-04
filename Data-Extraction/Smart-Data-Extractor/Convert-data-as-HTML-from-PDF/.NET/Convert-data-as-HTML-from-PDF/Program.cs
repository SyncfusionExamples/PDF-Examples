using Syncfusion.SmartDataExtractor;

using (FileStream stream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
	//Initialize the Data Extractor. 
	DataExtractor extractor = new DataExtractor();
	//Extract data as HTMl. 
	string htmlContent = extractor.ExtractDataAsHtml(stream);
	//Save the extracted Word data into an output file. 
	File.WriteAllText(Path.GetFullPath(@"Output/Output.html"), htmlContent);
}