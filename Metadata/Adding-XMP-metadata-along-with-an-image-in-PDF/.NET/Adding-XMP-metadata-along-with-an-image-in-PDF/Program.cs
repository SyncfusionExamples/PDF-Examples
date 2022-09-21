// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using System.Reflection.Metadata;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Load the image as stream which contains XMP metadata.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../Autumn Leaves.jpg"), FileMode.Open, FileAccess.Read);
PdfBitmap image = new PdfBitmap(imageStream, true);

//Draw the image.
graphics.DrawImage(image, 0, 0);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

