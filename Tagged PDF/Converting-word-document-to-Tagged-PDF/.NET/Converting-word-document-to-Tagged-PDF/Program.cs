// See https://aka.ms/new-console-template for more information

using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

//Open the file as Stream.
FileStream docStream = new FileStream(Path.GetFullPath("../../../Template.docx"), FileMode.Open, FileAccess.Read);

//Loads file stream into Word document.
WordDocument wordDocument = new WordDocument(docStream, Syncfusion.DocIO.FormatType.Automatic);

//Instantiation of DocIORenderer for Word to PDF conversion.
DocIORenderer render = new DocIORenderer();

//Sets true to preserve document structured tags in the converted PDF document.
render.Settings.AutoTag = true;

//Converts Word document into PDF document.
PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);

//Releases all resources used by the Word document and DocIO Renderer objects.
render.Dispose();
wordDocument.Dispose();

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
	//Save the PDF document to file stream.
	pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);