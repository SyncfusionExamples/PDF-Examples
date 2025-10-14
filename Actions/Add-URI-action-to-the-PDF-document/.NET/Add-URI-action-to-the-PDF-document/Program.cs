using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create a uri action.
    PdfUriAction uriAction = new PdfUriAction("http://www.google.com");

    //Add the action to the document.
    document.Actions.AfterOpen = uriAction;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}