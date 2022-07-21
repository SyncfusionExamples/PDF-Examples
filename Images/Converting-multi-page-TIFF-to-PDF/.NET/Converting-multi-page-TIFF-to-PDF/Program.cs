// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Set page margins.
document.PageSettings.Margins.All = 0;

//Load the multi frame TIFF image from the disk.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../image.tiff"), FileMode.Open, FileAccess.Read);
PdfTiffImage tiffImage = new PdfTiffImage(imageStream);

//Get the frame count.
int frameCount = tiffImage.FrameCount;

//Access each frame and draw into the page.
for (int i = 0; i < frameCount; i++)
{
    //Add new page to PDF document.
    PdfPage page = document.Pages.Add();

    //Create graphics for PDF page
    PdfGraphics graphics = page.Graphics;

    tiffImage.ActiveFrame = i;

    //Draw the image.
    graphics.DrawImage(tiffImage, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);
}

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream
    document.Save(outputFileStream);
}

//Close the document
document.Close(true);
