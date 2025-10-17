using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page into PdfLoadedPage.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Initialize a new PDF path.
    PdfPath path = new PdfPath();

    //Add line path points.
    path.AddLine(new PointF(10, 100), new PointF(10, 200));
    path.AddLine(new PointF(10, 200), new PointF(100, 100));
    path.AddLine(new PointF(100, 100), new PointF(100, 200));
    path.AddLine(new PointF(100, 200), new PointF(10, 100));

    //Draw the PDF path on page.
    loadedPage.Graphics.DrawPath(PdfPens.Black, path);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}