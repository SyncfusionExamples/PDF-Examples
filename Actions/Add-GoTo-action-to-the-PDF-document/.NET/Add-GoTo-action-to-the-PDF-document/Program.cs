using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add first page.
    PdfPage page = document.Pages.Add();

    //Add second page.
    PdfPage secondPage = document.Pages.Add();

    //Set the goto action.
    PdfGoToAction gotoAction = new PdfGoToAction(secondPage);

    //Set destination location.
    gotoAction.Destination = new PdfDestination(secondPage, new PointF(0, 100));

    //Add the action to the document. 
    document.Actions.AfterOpen = gotoAction;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

