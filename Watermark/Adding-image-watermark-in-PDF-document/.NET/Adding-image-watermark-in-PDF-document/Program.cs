// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Add a page to the PDF document.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create graphics for PDF page. 
PdfGraphics graphics = pdfPage.Graphics;

//Load the image as stream.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../design.png"), FileMode.Open, FileAccess.Read);

//Image watermark.
PdfImage image = new PdfBitmap(imageStream);

//Create state for page graphics. 
PdfGraphicsState state = graphics.Save();

//Set transparency for page graphics. 
graphics.SetTransparency(0.25f);

//Draw image in the page. 
graphics.DrawImage(image, new PointF(0, 0), pdfPage.Graphics.ClientSize);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);
