using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
class Program
{
    public static PdfDocument document;
    public static PdfFont font;

    static void Main(string[] args)
    {
        // Load the PDF documents
        PdfLoadedDocument doc1 = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input1.pdf"));
        PdfLoadedDocument doc2 = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input2.pdf"));
        PdfLoadedDocument doc3 = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input3.pdf"));
        object[] documentsToMerge = { doc1, doc2, doc3 };

        // Create a new PDF document
        using (document = new PdfDocument())
        {
            document.PageSettings.Size = doc1.Pages[0].Graphics.Size;

            // Add initial TOC page
            PdfPage tocPage = document.Pages.Add();
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);

            // Draw TOC title
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            tocPage.Graphics.DrawString("Table Of Contents", font, PdfBrushes.Black,
                new RectangleF(PointF.Empty, new SizeF(tocPage.Graphics.ClientSize.Width, 20)), format);

            // Merge the loaded documents into the new document
            PdfDocument.Merge(document, documentsToMerge);

            // Initialize TOC entry layout
            float currentY = 30;
            int totalEntries = 30;
            int pageOffset = 1;
            // Generate TOC entries dynamically
            for (int i = 0; i < totalEntries; i++)
            {
                // If current Y exceeds page height, add a new TOC page
                if (currentY > tocPage.Graphics.ClientSize.Height - 50)
                {
                    int currentPageIndex = document.Pages.IndexOf(tocPage);
                    tocPage = document.Pages.Add();
                    document.Pages.Insert(currentPageIndex + 1, tocPage);
                    currentY = 30;
                }

                // Calculate page index for bookmark
                int pageIndex = Math.Min(document.Pages.Count - 1, pageOffset + i);

                // Simulate long TOC entry title
                string longTitle = $"Chapter {i + 1} - This is a very long table of contents entry designed to test how the text wrapping functionality behaves when the content exceeds the width of the page layout in the PDF document.";

                // Add bookmark and TOC entry
                currentY = AddBookmark(document.Pages[pageIndex], tocPage, longTitle, currentY);
            }

            // Save the final PDF
            document.Save(Path.GetFullPath(@"Output/Output.pdf"));
        }
    }

    // Adds a bookmark and corresponding TOC entry to the document.
    private static float AddBookmark(PdfPage targetPage, PdfPage tocPage, string title, float currentY)
    {
        // Create bookmark
        PdfBookmark bookmark = document.Bookmarks.Add(title);

        // Add TOC entry and get updated Y position
        float newY = AddTableOfContent(targetPage, tocPage, title, new PointF(0, currentY));

        // Create named destination for navigation
        PdfNamedDestination namedDestination = new PdfNamedDestination(title)
        {
            Destination = new PdfDestination(targetPage, new PointF(0, currentY))
            {
                Mode = PdfDestinationMode.FitToPage
            }
        };

        document.NamedDestinationCollection.Add(namedDestination);
        bookmark.NamedDestination = namedDestination;

        return newY;
    }

    // Draws TOC entry text, page number, and adds clickable link annotation.
    private static float AddTableOfContent(PdfPage targetPage, PdfPage tocPage, string title, PointF position)
    {
        float textWidth = tocPage.Graphics.ClientSize.Width - 60;
        RectangleF textBounds = new RectangleF(position.X, position.Y, textWidth, 100);

        // Draw TOC entry text
        PdfTextElement textElement = new PdfTextElement(title, font, PdfBrushes.Blue);
        PdfLayoutFormat layoutFormat = new PdfLayoutFormat
        {
            Break = PdfLayoutBreakType.FitPage,
            Layout = PdfLayoutType.Paginate
        };

        PdfLayoutResult layoutResult = textElement.Draw(tocPage, textBounds, layoutFormat);

        // Draw page number
        string pageNumberText = (document.Pages.IndexOf(targetPage) + 1).ToString();
        PdfTextElement pageNumberElement = new PdfTextElement(pageNumberText, font, PdfBrushes.Black);
        pageNumberElement.Draw(tocPage, new PointF(tocPage.Graphics.ClientSize.Width - 40, position.Y));

        // Add clickable link annotation
        RectangleF bounds = layoutResult.Bounds;
        bounds.Width = textWidth;

        PdfDocumentLinkAnnotation linkAnnotation = new PdfDocumentLinkAnnotation(bounds)
        {
            AnnotationFlags = PdfAnnotationFlags.NoRotate,
            Text = title,
            Color = Color.Transparent,
            Destination = new PdfDestination(targetPage),
            Border = new PdfAnnotationBorder(0)
        };

        linkAnnotation.Destination.Location = position;
        tocPage.Annotations.Add(linkAnnotation);

        // Return updated Y position for next entry
        return layoutResult.Bounds.Bottom + 10;
    }
}