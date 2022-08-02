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

//Initialize pen to draw the bezier.
PdfPen pen = new PdfPen(PdfBrushes.Brown, 1f);

//Draw the bezier on PDF document.
loadedPage.Graphics.DrawBezier(pen, new PointF(10, 10), new PointF(10, 50), new PointF(50, 80), new PointF(80, 10));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
