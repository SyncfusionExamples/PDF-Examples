// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Create stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing PDF document.
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Get the first page from the document.
PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;

//Create a redaction object.
PdfRedaction redaction = new PdfRedaction(new RectangleF(343, 147, 60, 17), Syncfusion.Drawing.Color.Black);

//Add a redaction object into the redaction collection of loaded page.
page.AddRedaction(redaction);

//Redact the contents from the PDF document.
document.Redact();

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
