using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the PDF document.
    PdfPage pdfPage = document.Pages.Add();

    //Create graphics for PDF page. 
    PdfGraphics graphics = pdfPage.Graphics;

    //Load the image as stream.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/design.png"), FileMode.Open, FileAccess.Read);

    //Image watermark.
    PdfImage image = new PdfBitmap(imageStream);

    //Create state for page graphics. 
    PdfGraphicsState state = graphics.Save();

    //Set transparency for page graphics. 
    graphics.SetTransparency(0.25f);

    //Draw image in the page. 
    graphics.DrawImage(image, new PointF(0, 0), pdfPage.Graphics.ClientSize);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

