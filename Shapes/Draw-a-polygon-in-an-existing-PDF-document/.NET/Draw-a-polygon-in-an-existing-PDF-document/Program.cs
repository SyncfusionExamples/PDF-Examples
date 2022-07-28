// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document as stream.
FileStream inputStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);

//Get the page into PdfLoadedPage.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Initialize PdfPen to draw the polygon.
PdfPen pen = new PdfPen(PdfBrushes.Brown, 10f);

//Initialize PdfLinearGradientBrush for drawing the polygon.
PdfLinearGradientBrush brush = new PdfLinearGradientBrush(new PointF(10, 100), new PointF(100, 200), new PdfColor(Color.Red), new PdfColor(Color.Green));

//Create the polygon points.
PointF p1 = new PointF(10, 100);
PointF p2 = new PointF(10, 200);
PointF p3 = new PointF(100, 100);
PointF p4 = new PointF(100, 200);
PointF p5 = new PointF(55, 150);
PointF[] points = { p1, p2, p3, p4, p5 };

//Draw the polygon on PDF document.
loadedPage.Graphics.DrawPolygon(pen, brush, points);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);