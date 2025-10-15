using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Get stream from the existing image file. 
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Autumn Leaves.jpg"), FileMode.Open, FileAccess.Read);

    //Load the image file. 
    PdfBitmap image = new PdfBitmap(imageStream);

    //Draw the image.
    graphics.DrawImage(image, 0, 0);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}