// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a PDF document.
PdfDocument document = new PdfDocument();

//Add pages to the document.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Get stream from the existing TIF file. 
FileStream imageStream = new FileStream(Path.GetFullPath("../../../image.tif"), FileMode.Open, FileAccess.Read);

//Load the image from stream. 
PdfTiffImage image = new PdfTiffImage(imageStream);

//Get stream from the image file. 
FileStream maskStream = new FileStream(Path.GetFullPath("../../../mask2.bmp"), FileMode.Open, FileAccess.Read);

//Load the image mask file from stream. 
PdfImageMask mask = new PdfImageMask(new PdfTiffImage(maskStream));

//Assign the masking image to TIF image. 
image.Mask = mask;

//Draw the image.
graphics.DrawImage(image, 0, 0);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream
    document.Save(outputFileStream);
}

//Close the document
document.Close(true);

