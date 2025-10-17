using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add pages to PDF document. 
    document.Pages.Add();
    document.Pages.Add();

    //Create a named action.
    PdfNamedAction namedAction = new PdfNamedAction(PdfActionDestination.LastPage);

    //Add the named action.
    document.Actions.AfterOpen = namedAction;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

