// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

// Create FileStream object to read the input PDF file
using (FileStream inputFileStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the PDF document from the input stream
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream))
    {
        // Get the first page of the PDF document
        PdfPageBase loadedPage = loadedDocument.Pages[0];

        // Create a PDF font to add a watermark text.
        PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 32);

        // Measure the watermark text and get the size
        string watermarkText = "Created using Syncfusion PDF library";
        SizeF watermarkTextSize = font.MeasureString(watermarkText);

        // Move the graphics to the center of the page
        loadedPage.Graphics.Save();
        loadedPage.Graphics.TranslateTransform(loadedPage.Size.Width / 2, loadedPage.Size.Height / 2);

        // Rotate the graphics to 45 degrees
        loadedPage.Graphics.RotateTransform(-45);

        // Draw the watermark text
        loadedPage.Graphics.DrawString(watermarkText, font, PdfBrushes.Red, new PointF(-watermarkTextSize.Width / 2, -watermarkTextSize.Height / 2));

        // Restore the graphics
        loadedPage.Graphics.Restore();

        //Create file stream.
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
        {
            //Save the PDF document to file stream.
            loadedDocument.Save(outputFileStream);
        }
    }
}

