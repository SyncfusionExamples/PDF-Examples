using Syncfusion.DocIO.DLS;
using Syncfusion.SmartDataExtractor;

//Open the input PDF file as a stream.
using (FileStream stream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
{
	//Initialize the Data Extractor.
	DataExtractor extractor = new DataExtractor();
	//Extract data as Excel Document.
	IWorkbook excel = extractor.ExtractDataAsExcel(stream);
	//Save the extracted excel data into an output file.
	excel.Save(Path.GetFullPath(@"Output/Output.docx"));
	excel.Close();
}
