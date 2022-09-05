// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the first page of the document
PdfPageBase page = loadedDocument.Pages[0];

//Create an instance for named destination.
PdfNamedDestination destination = new PdfNamedDestination("TOC");

//Add the destination page. 
destination.Destination = new PdfDestination(page);

//Set the location.
destination.Destination.Location = new PointF(0, 500);

//Set zoom factor to 400 percentage.
destination.Destination.Zoom = 4;

//Add the namded destination to the PDF document. 
loadedDocument.NamedDestinationCollection.Add(destination);

//Create an instance for named destination.
PdfNamedDestination destination1 = new PdfNamedDestination("POC");

//Add the destination page. 
destination1.Destination = new PdfDestination(page);

//Set the location.
destination1.Destination.Location = new PointF(0, 100);

//Set zoom factor to 400 percentage.
destination1.Destination.Zoom = 4;

//Add the namded destination to the PDF document. 
loadedDocument.NamedDestinationCollection.Add(destination1);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
