// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Initialize the pen for drawing pie.
PdfPen pen = new PdfPen(PdfBrushes.Brown, 5f);

//Set the line join style of the pen.
pen.LineJoin = PdfLineJoin.Round;

//Set the bounds for pie.
RectangleF rectangle = new RectangleF(10, 50, 200, 200);

//Draw the pie on PDF document.
page.Graphics.DrawPie(pen, PdfBrushes.Green, rectangle, 180, 60);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);