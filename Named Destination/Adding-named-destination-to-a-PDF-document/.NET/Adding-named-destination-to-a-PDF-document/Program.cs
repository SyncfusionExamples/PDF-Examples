using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Create an instance for named destination.
    PdfNamedDestination destination = new PdfNamedDestination("TOC");
    destination.Destination = new PdfDestination(page);

    //Set the location.
    destination.Destination.Location = new PointF(0, 500);

    //Set zoom factor to 400 percentage.
    destination.Destination.Zoom = 4;

    //Add the named destination to document. 
    document.NamedDestinationCollection.Add(destination);

    //Draw the text.
    page.Graphics.DrawString("Hello World!!", new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new PointF(0, 500));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}