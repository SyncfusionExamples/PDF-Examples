// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Initialize pen to draw the line.
PdfPen pen = new PdfPen(PdfBrushes.Black, 5f);

//Create the line points.
PointF point1 = new PointF(10, 10);
PointF point2 = new PointF(10, 100);

//Draw the line on PDF document.
page.Graphics.DrawLine(pen, point1, point2);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);