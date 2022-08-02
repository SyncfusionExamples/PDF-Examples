// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Initialize PdfGraphics for PdfPage.
PdfGraphics graphics = page.Graphics;

//Create new instance of PdfBezierCurve.
PdfBezierCurve bezier = new PdfBezierCurve(new PointF(0, 0), new PointF(100, 50), new PointF(50, 50), new PointF(100, 100));

//Draw the bezier curve on PDF document.
bezier.Draw(graphics, new PointF(10, 10));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);