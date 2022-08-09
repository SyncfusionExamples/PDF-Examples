// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing PDF document.
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Get the first page from the document.
PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;

//Create a PDF redaction for the page.
PdfRedaction redaction = new PdfRedaction(new RectangleF(341, 149, 64, 14));

//Draw a mosaic pattern on the redaction bounds.
RectangleF rect = new RectangleF(0, 0, 8, 8);

//Create tilling brush. 
PdfTilingBrush tillingBrush = new PdfTilingBrush(rect);
tillingBrush.Graphics.DrawRectangle(PdfBrushes.Gray, new RectangleF(0, 0, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.White, new RectangleF(2, 0, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.LightGray, new RectangleF(4, 0, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.DarkGray, new RectangleF(6, 0, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.White, new RectangleF(0, 2, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.LightGray, new RectangleF(2, 2, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.Black, new RectangleF(4, 2, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.LightGray, new RectangleF(6, 2, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.LightGray, new RectangleF(0, 4, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.DarkGray, new RectangleF(2, 4, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.LightGray, new RectangleF(4, 4, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.White, new RectangleF(6, 4, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.Black, new RectangleF(0, 6, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.LightGray, new RectangleF(2, 6, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.Black, new RectangleF(4, 6, 2, 2));
tillingBrush.Graphics.DrawRectangle(PdfBrushes.DarkGray, new RectangleF(6, 6, 2, 2));

rect = new RectangleF(0, 0, 16, 14); PdfTilingBrush tillingBrushNew = new PdfTilingBrush(rect);
tillingBrushNew.Graphics.DrawRectangle(tillingBrush, rect);

//Draw rectangle in the redaction appearance. 
redaction.Appearance.Graphics.DrawRectangle(tillingBrushNew, new RectangleF(0, 0, 64, 14));

//Add a redaction object into the redaction collection of loaded page.
page.AddRedaction(redaction);

//Redact the contents from the PDF document.
document.Redact();

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);