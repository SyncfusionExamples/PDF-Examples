// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing PDF document from stream. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the first page.
PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

//Create redaction.
PdfRedaction redaction = new PdfRedaction(new RectangleF(343, 147, 60, 17), Color.Black);

//Add redaction to the loaded page.
page.AddRedaction(redaction);

loadedDocument.RedactionProgress += redaction_TrackProgress;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
	//Save the PDF document to file stream.
	loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);

//Event handler for Track redaction process.
void redaction_TrackProgress(object sender, RedactionProgressEventArgs arguments)
{
	//Write the redaction progress in console window. 
    Console.WriteLine(String.Format("Redaction Process " + arguments.Progress + " % completed"));
}

Console.ReadLine();
