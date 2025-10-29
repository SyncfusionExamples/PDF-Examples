using SkiaSharp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

// Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Handle font substitution during PDF/A conversion
    loadedDocument.SubstituteFont += LoadedDocument_SubstituteFont;
    // Convert the document to PDF/A-1B format
    loadedDocument.ConvertToPDFA(PdfConformanceLevel.Pdf_A1B);
    // Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

// Event handler to substitute missing fonts during conversion
void LoadedDocument_SubstituteFont(object sender, PdfFontEventArgs args)
{
    // Extract the font name (ignoring style suffixes)
    string fontName = args.FontName.Split(',')[0];
    // Determine the font style
    PdfFontStyle fontStyle = args.FontStyle;
    SKFontStyle skFontStyle = SKFontStyle.Normal;
    // Map PDF font styles to SkiaSharp font styles
    if (fontStyle == PdfFontStyle.Bold)
        skFontStyle = SKFontStyle.Bold;
    else if (fontStyle == PdfFontStyle.Italic)
        skFontStyle = SKFontStyle.Italic;
    else if (fontStyle == (PdfFontStyle.Bold | PdfFontStyle.Italic))
        skFontStyle = SKFontStyle.BoldItalic;
    // Load the typeface using SkiaSharp
    SKTypeface typeface = SKTypeface.FromFamilyName(fontName, skFontStyle);
    SKStreamAsset typeFaceStream = typeface.OpenStream();

    // Create a memory stream from the font data
    MemoryStream memoryStream = null;
    if (typeFaceStream != null && typeFaceStream.Length > 0)
    {
        byte[] fontData = new byte[typeFaceStream.Length];
        typeFaceStream.Read(fontData, fontData.Length);
        typeFaceStream.Dispose();
        memoryStream = new MemoryStream(fontData);
    }
    // Assign the font stream to the event arguments
    args.FontStream = memoryStream;
}