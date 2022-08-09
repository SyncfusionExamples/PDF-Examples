// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new document.
PdfDocument document = new PdfDocument();

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

