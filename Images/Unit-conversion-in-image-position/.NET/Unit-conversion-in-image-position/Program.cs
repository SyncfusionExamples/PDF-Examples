using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    using (FileStream stream = new FileStream(Path.GetFullPath(@"Data/Input.png"), FileMode.Open, FileAccess.Read))
    {
        //Load the image from the disk
        PdfBitmap image = new PdfBitmap(stream);

        //Add the first section to the PDF document
        PdfSection section = document.Sections.Add();

        //Initialize unit converter
        PdfUnitConverter converter = new PdfUnitConverter();

        //Convert the image size from pixel to points
        SizeF size = converter.ConvertFromPixels(image.PhysicalDimension, PdfGraphicsUnit.Point);

        //Set section size based on the image size
        section.PageSettings.Size = size;

        // Set section orientation based on the image size (by default Portrait) 
        if (image.Width > image.Height)
            section.PageSettings.Orientation = PdfPageOrientation.Landscape;

        //Set a margin for the section
        section.PageSettings.Margins.All = 0;

        //Add a page to the section
        PdfPage page = section.Pages.Add();

        //Draw image
        page.Graphics.DrawImage(image, 0, 0);

        //Save the document
        document.Save(Path.GetFullPath(@"Output/Output.pdf"));
    }
}