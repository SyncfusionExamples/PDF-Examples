// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the page. 
PdfPageBase loadedPage = loadedDocument.Pages[0];

//Create graphics for PDF page. 
PdfGraphics graphics = loadedPage.Graphics;

//Load the image file as stream.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../design.png"), FileMode.Open, FileAccess.Read);

//Load the image file.
PdfImage image = new PdfBitmap(imageStream);

//Create state for page graphics. 
PdfGraphicsState state = graphics.Save();

//Set transparency for page graphics. 
graphics.SetTransparency(0.25f);

//Draw image watermark in PDF page. 
graphics.DrawImage(image, new PointF(0, 0), loadedPage.Graphics.ClientSize);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);