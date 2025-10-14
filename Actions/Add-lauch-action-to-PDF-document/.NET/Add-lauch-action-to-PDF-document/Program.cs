using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create and add new launch Action to the document.
    PdfLaunchAction action = new PdfLaunchAction(Path.GetFullPath(@"Data/logo.png"));
    document.Actions.AfterOpen = action;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
