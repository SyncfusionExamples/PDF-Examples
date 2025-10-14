using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the page. 
    PdfPageBase loadedPage = loadedDocument.Pages[0];

    //Create graphics for PDF page. 
    PdfGraphics graphics = loadedPage.Graphics;

    //Load the image file as stream.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/design.png"), FileMode.Open, FileAccess.Read);

    //Load the image file.
    PdfImage image = new PdfBitmap(imageStream);

    //Create state for page graphics. 
    PdfGraphicsState state = graphics.Save();

    //Set transparency for page graphics. 
    graphics.SetTransparency(0.25f);

    //Draw image watermark in PDF page. 
    graphics.DrawImage(image, new PointF(0, 0), loadedPage.Graphics.ClientSize);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}