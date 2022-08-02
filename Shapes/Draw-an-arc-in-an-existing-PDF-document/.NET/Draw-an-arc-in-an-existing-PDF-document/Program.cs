// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream inputStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);

//Get the page into PdfLoadedPage.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Initialize the pen for drawing an arc.
PdfPen pen = new PdfPen(Color.Brown, 10f);

//Set the line join style of the pen.
pen.LineCap = PdfLineCap.Square;

//Set the bounds for arc.
RectangleF bounds = new RectangleF(20, 40, 200, 200);

//Draw the arc on PDF document.
loadedPage.Graphics.DrawArc(pen, bounds, 270, 90);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);