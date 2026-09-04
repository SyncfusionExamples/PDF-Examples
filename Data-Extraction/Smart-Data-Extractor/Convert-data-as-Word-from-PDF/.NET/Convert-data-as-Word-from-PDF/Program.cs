using Syncfusion.DocIO.DLS;
using Syncfusion.SmartDataExtractor;

//Open the input PDF file as a stream.
using (FileStream stream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
{
	//Initialize the Data Extractor.
	DataExtractor extractor = new DataExtractor();
	//Extract data as WordDocument.
	WordDocument word = extractor.ExtractDataAsWordDocument(stream);
	//Save the extracted Word data into an output file.
	word.Save(Path.GetFullPath(@"Output/Output.docx")); ;
	word.Close();
}
