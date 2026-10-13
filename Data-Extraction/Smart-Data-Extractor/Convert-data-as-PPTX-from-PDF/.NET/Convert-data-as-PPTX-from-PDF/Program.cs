using Syncfusion.Presentation;
using Syncfusion.SmartDataExtractor;

//Open the input PDF file as a stream.
using (FileStream stream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.ReadWrite))
{
	//Initialize the Data Extractor.
	DataExtractor extractor = new DataExtractor();
    //Extract data as Presentation.
    IPresentation pptxDoc = extractor.ExtractDataAsPresentation(stream);
    //Save the extracted pptx data into an output file.
    pptxDoc.Save(Path.GetFullPath(@"Output/Output.pptx"));
    pptxDoc.Close();
}
