using Syncfusion.Pdf;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

// Load the input PDF document
using (PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Loop through every page in the PDF
    foreach (PdfLoadedPage page in document.Pages)
    {
        PdfLoadedPage loadedPage = page as PdfLoadedPage;
        // Get graphics object to draw on the page
        PdfGraphics graphics = loadedPage.Graphics;
        // Get all images present in the current page
        PdfImageInfo[] imageInfos = loadedPage.GetImagesInfo();
        // If no images found, skip this page
        if (imageInfos == null || imageInfos.Length == 0) continue;
        // Font for overlay text
        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12f);
        // Center the overlay text inside the image area
        PdfStringFormat centerFormat = new PdfStringFormat
        {
            Alignment = PdfTextAlignment.Center,
            LineAlignment = PdfVerticalAlignment.Middle
        };
        // Save the current graphics state
        graphics.Save();
        // Draw overlay text ("Image removed") on top of each image area
        foreach (PdfImageInfo info in imageInfos)
        {
            string overlayText = "Image removed";

            graphics.DrawString(
                overlayText,
                font,
                PdfBrushes.Red,
                info.Bounds,       // Draw the text inside the image area
                centerFormat
            );
        }
        // Restore the graphics state after drawing
        graphics.Restore();
        // Remove the images from the PDF page
        foreach (PdfImageInfo info in imageInfos)
        {
            loadedPage.RemoveImage(info);
        }
    }
    // Save the output PDF
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

