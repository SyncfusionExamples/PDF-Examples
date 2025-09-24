using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Set document metadata
    document.DocumentInformation.Title = "Tagged PDF with Top-Centered Image and Text";

    // Add a new page
    PdfPage page = document.Pages.Add();

    // Load image stream
    using (FileStream imgStream = new FileStream(Path.GetFullPath(@"Data/Image.jpg"), FileMode.Open, FileAccess.Read))
    {
        PdfBitmap image = new PdfBitmap(imgStream);

        // Define desired image size
        float imageWidth = 200;
        float imageHeight = 100;

        // Calculate X and Y to center image at the top
        float pageWidth = page.Graphics.ClientSize.Width;
        float imageX = (pageWidth - imageWidth) / 2;
        float imageY = 20;

        // Set the tag type and alternate text for accessibility
        PdfStructureElement imageElement = new PdfStructureElement(PdfTagType.Figure)
        {
            AlternateText = "GreenTree"
        };
        image.PdfTag = imageElement;

        // Draw the image at the top center
        page.Graphics.DrawImage(image, new RectangleF(imageX, imageY, imageWidth, imageHeight));

        // Add paragraph text below the image
        string paragraphText =
            "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. "
            + "The company manufactures and sells metal and composite bicycles to North American, European, and Asian commercial markets. "
            + "While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base. "
            + "The company is known for its commitment to innovation, quality, and customer satisfaction, catering to both amateur and professional cycling enthusiasts.\n\n"
            + "In addition to bicycles, Adventure Works Cycles also provides a wide range of cycling accessories, apparel, and maintenance tools through retail and online platforms. "
            + "The company invests heavily in research and development to improve performance and safety in its products. "
            + "With an integrated global supply chain, efficient logistics operations, and a customer-centric approach, Adventure Works Cycles continues to be a recognized brand in the global cycling industry.";

        // Create structure element for paragraph
        PdfStructureElement paragraphStructure = new PdfStructureElement(PdfTagType.Paragraph)
        {
            ActualText = "Company introduction paragraph"
        };

        // Create and configure the text element
        PdfTextElement textElement = new PdfTextElement(paragraphText)
        {
            PdfTag = paragraphStructure,
            Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12),
            Brush = new PdfSolidBrush(new PdfColor(89, 89, 93))
        };

        // Draw the text below the image
        float textY = imageY + imageHeight + 20;
        textElement.Draw(page, new RectangleF(20, textY, pageWidth - 40, 400));
    }

    // Save the PDF document
    using (FileStream outputFile = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        document.Save(outputFile);
    }
}