using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the first page.
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create redaction.
    PdfRedaction redaction = new PdfRedaction(new RectangleF(343, 147, 60, 17), Color.Black);

    //Add redaction to the loaded page.
    page.AddRedaction(redaction);

    loadedDocument.RedactionProgress += redaction_TrackProgress;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

//Event handler for Track redaction process.
void redaction_TrackProgress(object sender, RedactionProgressEventArgs arguments)
{
	//Write the redaction progress in console window. 
    Console.WriteLine(String.Format("Redaction Process " + arguments.Progress + " % completed"));
}

Console.ReadLine();
