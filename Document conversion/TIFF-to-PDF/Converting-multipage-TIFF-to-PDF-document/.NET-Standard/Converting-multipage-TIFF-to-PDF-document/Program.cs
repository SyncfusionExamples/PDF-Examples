// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Load the multi frame TIFF image from the disk.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../image.tiff"), FileMode.Open, FileAccess.Read);

//Initialize TIFF image class. 
PdfTiffImage tiffImage = new PdfTiffImage(imageStream);

//Get the frame count.
int frameCount = tiffImage.FrameCount;

//Access each frame and draw into the page.
for (int i = 0; i < frameCount; i++)
{
    //Add a section to the PDF document.
    PdfSection section = document.Sections.Add();

    //Set page margins.
    section.PageSettings.Margins.All = 0;
    tiffImage.ActiveFrame = i;

    //Create a PDF unit converter instance.
    PdfUnitConvertor converter = new PdfUnitConvertor();

    //Convert to point.
    Syncfusion.Drawing.SizeF size = converter.ConvertFromPixels(tiffImage.PhysicalDimension, PdfGraphicsUnit.Point);

    //Set page orientation.
    section.PageSettings.Orientation = (size.Width > size.Height) ? PdfPageOrientation.Landscape : PdfPageOrientation.Portrait;

    //Set page size.
    section.PageSettings.Size = size;

    //Add a page to the section.
    PdfPage page = section.Pages.Add();

    //Draw TIFF image into the PDF page.
    page.Graphics.DrawImage(tiffImage, Syncfusion.Drawing.PointF.Empty, size);
}

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../TIFFToPDFDocument.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
