using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get first page from document.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create PDF graphics for the page.
    PdfGraphics graphics = loadedPage.Graphics;

    //Get stream from the existing image file. 
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Autumn Leaves.jpg"), FileMode.Open, FileAccess.Read);

    //Load the image from the disk.
    PdfBitmap image = new PdfBitmap(imageStream);

    //Draw the image. 
    graphics.DrawImage(image, 0, 0);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

