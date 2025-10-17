using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page into PdfLoadedPage.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Initialize pen to draw the line.
    PdfPen pen = new PdfPen(PdfBrushes.Black, 5f);

    //Create the line points.
    PointF point1 = new PointF(10, 10);
    PointF point2 = new PointF(10, 100);

    //Draw the line on PDF document.
    loadedPage.Graphics.DrawLine(pen, point1, point2);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}