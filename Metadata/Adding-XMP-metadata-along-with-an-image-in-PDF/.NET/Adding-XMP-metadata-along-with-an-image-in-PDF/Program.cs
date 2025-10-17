using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using System.Reflection.Metadata;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Load the image as stream which contains XMP metadata.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Autumn Leaves.jpg"), FileMode.Open, FileAccess.Read);
    PdfBitmap image = new PdfBitmap(imageStream, true);

    //Draw the image.
    graphics.DrawImage(image, 0, 0);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

