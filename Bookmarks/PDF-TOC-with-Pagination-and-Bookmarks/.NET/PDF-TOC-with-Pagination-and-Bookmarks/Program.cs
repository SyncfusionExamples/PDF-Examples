using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
class Program
{
    static PdfDocument document;
    static PdfFont font;

    static void Main(string[] args)
    {
        // Load single PDF
        PdfLoadedDocument loadedDoc = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
        // Create new document
        using (document = new PdfDocument())
        {
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
            // Add TOC page first
            PdfPage tocPage = document.Pages.Add();
            tocPage.Graphics.DrawString(
                "Table Of Contents",
                new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold),
                PdfBrushes.Black,
                new PointF(200, 10)
            );
            float currentY = 40;
            // Copy pages from loaded document
            foreach (PdfLoadedPage page in loadedDoc.Pages)
            {
                PdfPage newPage = document.Pages.Add();
                newPage.Graphics.DrawPdfTemplate(page.CreateTemplate(), PointF.Empty);
            }

            PdfStringFormat format = new PdfStringFormat();
            format.WordWrap = PdfWordWrapType.Word;

            float leftMargin = 20;
            // Total usable width (page width - margins)
            float pageWidth = tocPage.GetClientSize().Width - (leftMargin * 2);
            // 3/4 for title, 1/4 for page number
            float titleWidth = pageWidth * 0.75f;
            float pageNumWidth = pageWidth * 0.25f;

            for (int i = 1; i < document.Pages.Count; i++)
            {
                string longTitle = $"This is a very long table of contents entry designed to test how the text wrapping functionality behaves when the content exceeds the width of the page layout in the PDF document.";
                PdfPage targetPage = document.Pages[i];
                // Bookmark
                PdfBookmark bookmark = document.Bookmarks.Add(longTitle);
                bookmark.Destination = new PdfDestination(targetPage);
                // Measure height based on 3/4 width
                SizeF textSize = font.MeasureString(longTitle, new SizeF(titleWidth, float.MaxValue), format);
                // Draw WITHOUT explicit rectangle variable
                tocPage.Graphics.DrawString(
                    longTitle,
                    font,
                    PdfBrushes.Blue,
                    new RectangleF(leftMargin, currentY, titleWidth, textSize.Height),
                    format
                );
                // Page number in remaining 1/4 space (right aligned)
                PdfStringFormat rightAlign = new PdfStringFormat();
                rightAlign.Alignment = PdfTextAlignment.Right;
                tocPage.Graphics.DrawString(
                    (i+1).ToString(),
                    font,
                    PdfBrushes.Black,
                    new RectangleF(leftMargin + titleWidth, currentY, pageNumWidth, textSize.Height),
                    rightAlign
                );
                PdfDocumentLinkAnnotation link = new PdfDocumentLinkAnnotation(
                    new RectangleF(leftMargin, currentY, titleWidth, textSize.Height)
                );
                link.Destination = new PdfDestination(targetPage);
                // REMOVE BORDER
                link.Border = new PdfAnnotationBorder(0);
                tocPage.Annotations.Add(link);
                currentY += textSize.Height + 5;
            }
            // Add page numbers (pagination)
            for (int i = 0; i < document.Pages.Count; i++)
            {
                PdfPage page = document.Pages[i];
                page.Graphics.DrawString(
                    "Page " + (i + 1),
                    font,
                    PdfBrushes.Black,
                    new PointF(page.GetClientSize().Width - 80, page.GetClientSize().Height - 20)

                );
            }
            // Save file
            document.Save(Path.GetFullPath(@"Output/Output.pdf"));
        }
    }  
}