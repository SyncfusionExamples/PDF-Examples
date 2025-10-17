using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page into PdfLoadedPage.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Initialize pen to draw the bezier.
    PdfPen pen = new PdfPen(PdfBrushes.Brown, 1f);

    //Draw the bezier on PDF document.
    loadedPage.Graphics.DrawBezier(pen, new PointF(10, 10), new PointF(10, 50), new PointF(50, 80), new PointF(80, 10));

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
