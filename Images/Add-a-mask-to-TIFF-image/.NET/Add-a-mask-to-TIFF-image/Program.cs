using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add pages to the document.
    PdfPage page = document.Pages.Add();

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Get stream from the existing TIF file. 
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/image.tif"), FileMode.Open, FileAccess.Read);

    //Load the image from stream. 
    PdfTiffImage image = new PdfTiffImage(imageStream);

    //Get stream from the image file. 
    FileStream maskStream = new FileStream(Path.GetFullPath(@"Data/mask2.bmp"), FileMode.Open, FileAccess.Read);

    //Load the image mask file from stream. 
    PdfImageMask mask = new PdfImageMask(new PdfTiffImage(maskStream));

    //Assign the masking image to TIF image. 
    image.Mask = mask;

    //Draw the image.
    graphics.DrawImage(image, 0, 0);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

