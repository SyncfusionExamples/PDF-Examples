// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Initialize pen to draw the bezier.
PdfPen pen = new PdfPen(PdfBrushes.Brown, 1f);

//Draw the bezier on PDF document.
page.Graphics.DrawBezier(pen, new PointF(10, 10), new PointF(10, 50), new PointF(50, 80), new PointF(80, 10));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{   
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
