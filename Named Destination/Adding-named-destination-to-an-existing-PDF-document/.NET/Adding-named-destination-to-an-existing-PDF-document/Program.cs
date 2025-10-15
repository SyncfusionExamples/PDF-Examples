using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
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

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
