using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

// Open the image once; reuse for all redactions.
using FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Image.jpg"), FileMode.Open, FileAccess.Read);
PdfBitmap image = new PdfBitmap(imageStream);

// Load the source PDF.
using (PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Find all bounds of the search text across pages.
    Dictionary<int, List<RectangleF>> hits;
    document.FindText("Fusce", out hits);
    // For each page with matches
    foreach (KeyValuePair<int, List<RectangleF>> kvp in hits)
    {
        int pageIndex = kvp.Key;
        PdfLoadedPage page = document.Pages[pageIndex] as PdfLoadedPage;
        // Replace each matched region by drawing the image in a redaction appearance.
        foreach (RectangleF match in kvp.Value)
        {
            float pad = 1f; // Small padding around the text box.
            RectangleF box = new RectangleF(
                match.X - pad,
                match.Y - pad,
                match.Width + pad * 2,
                match.Height + pad * 2
            );
            // Create a transparent redaction over the text area.
            PdfRedaction redaction = new PdfRedaction(box, Color.Transparent);
            // Draw the image to fully cover the redaction area (stretched to fit).
            RectangleF dest = new RectangleF(0, 0, box.Width, box.Height);
            redaction.Appearance.Graphics.DrawImage(image, dest);
            // Add the redaction to the page.
            page.AddRedaction(redaction);
        }
    }
    // Apply all redactions so the text is removed and image overlays are finalized.
    document.Redact();
    // Save the result.
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}