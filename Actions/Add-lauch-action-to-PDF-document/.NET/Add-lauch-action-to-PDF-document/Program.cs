// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Create and add new launch Action to the document.
PdfLaunchAction action = new PdfLaunchAction(Path.GetFullPath("../../../logo.png"));
document.Actions.AfterOpen = action;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
	//Save the PDF document to file stream.
	document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
