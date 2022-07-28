// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Initialize a new PDF path.
PdfPath path = new PdfPath();

//Add line path points.
path.AddLine(new PointF(10, 100), new PointF(10, 200));
path.AddLine(new PointF(10, 200), new PointF(100, 100));
path.AddLine(new PointF(100, 100), new PointF(100, 200));
path.AddLine(new PointF(100, 200), new PointF(10, 100));

//Draw the PDF path on page.
page.Graphics.DrawPath(PdfPens.Black, path);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);