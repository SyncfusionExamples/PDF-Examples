// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new document.
PdfDocument document = new PdfDocument();

//Add pages to PDF document. 
document.Pages.Add();
document.Pages.Add();

//Create a named action.
PdfNamedAction namedAction = new PdfNamedAction(PdfActionDestination.LastPage);

//Add the named action.
document.Actions.AfterOpen = namedAction;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
	//Save the PDF document to file stream.
	document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

