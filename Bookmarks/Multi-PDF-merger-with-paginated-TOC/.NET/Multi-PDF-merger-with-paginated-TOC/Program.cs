using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System.Collections.Generic;

class Program
{
    public static PdfDocument document;
    public static PdfFont font;

    static void Main(string[] args)
    {
        // Load source PDFs using file streams
        using (FileStream fsharpStream = new FileStream(Path.GetFullPath(@"Data/Fsharp_Succinctly.pdf"), FileMode.Open, FileAccess.Read))
        using (PdfLoadedDocument fsharpDoc = new PdfLoadedDocument(fsharpStream))

        using (FileStream httpStream = new FileStream(Path.GetFullPath(@"Data/HTTP_Succinctly.pdf"), FileMode.Open, FileAccess.Read))
        using (PdfLoadedDocument httpDoc = new PdfLoadedDocument(httpStream))

        using (FileStream windowsStoreStream = new FileStream(Path.GetFullPath(@"Data/WindowsStoreApps_Succinctly.pdf"), FileMode.Open, FileAccess.Read))
        using (PdfLoadedDocument windowsStoreDoc = new PdfLoadedDocument(windowsStoreStream))
        {

            // Store all loaded documents in an array
            PdfLoadedDocument[] docs = { fsharpDoc, httpDoc, windowsStoreDoc };


            // Create new document
            document = new PdfDocument();
            document.PageSettings.Size = fsharpDoc.Pages[0].Size;

            // Estimate TOC pages needed
            int totalEntries = 60;
            int entriesPerPage = 30;
            int tocPages = (int)Math.Ceiling(totalEntries / (double)entriesPerPage);

            // Add TOC pages
            List<PdfPage> tocPagesList = new List<PdfPage>();
            for (int i = 0; i < tocPages; i++)
            {
                PdfPage tocPage = document.Pages.Add();
                tocPagesList.Add(tocPage);
                if (i == 0)
                {
                    font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);
                    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                    tocPage.Graphics.DrawString("Table Of Contents", font, PdfBrushes.Black,
                        new RectangleF(PointF.Empty, new SizeF(tocPage.Graphics.ClientSize.Width, 20)), format);
                }
            }

            // Merge PDFs after TOC pages
            PdfDocument.Merge(document, docs);

            // Define TOC entries (title and corresponding page index)
            List<(string Title, int PageIndex)> tocEntries = GetTocEntries();

            // Adjust TOC entries
            tocEntries = AdjustTOCEntriesWithOffset(tocEntries, tocPages);
            // Draw TOC entries
            float currentY = 30;
            int tocPageIndex = 0;
            PdfPage currentTocPage = tocPagesList[tocPageIndex];
            foreach (var (title, pageIndex) in tocEntries)
            {
                if (currentY > currentTocPage.Graphics.ClientSize.Height - 50)
                {
                    tocPageIndex++;
                    currentTocPage = tocPagesList[tocPageIndex];
                    currentY = 30;
                }

                currentY = AddBookmark(document.Pages[pageIndex], currentTocPage, title, currentY);
            }

            //Create file stream.
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            //Close the document
            document.Close(true);
        }
    }

    // Generates a list of Table of Contents (TOC) entries with titles and corresponding page indices.
    static List<(string Title, int PageIndex)> GetTocEntries()
    {
        List<(string Title, int PageIndex)> entries = new List<(string, int)>();

        for (int i = 1; i <= 60; i++)
        {
            // Pages 1–20: F# document
            if (i <= 20)
            {
                entries.Add(($"F# - This is first document {i}", i));
            }
            // Pages 21–40: HTTP document
            else if (i > 20 && i <= 40)
            {
                entries.Add(($"HTTP - This is second document {i}", i));
            }
            // Pages 41–60: Windows Store Apps document
            else
            {
                entries.Add(($"Windows Store Apps - This is third document {i}", i));
            }
        }

        return entries;
    }

    //Adjusts the page indices of the Table of Contents (TOC) entries by adding an offset.
    public static List<(string Title, int PageIndex)> AdjustTOCEntriesWithOffset(List<(string Title, int PageIndex)> tocEntries, int tocPages)
    {
        List<(string, int)> adjustedList = new List<(string, int)>();

        // Loop through each TOC entry and add the TOC page count to its page index
        foreach (var (title, pageIndex) in tocEntries)
        {
            adjustedList.Add((title, pageIndex + tocPages));
        }

        return adjustedList;
    }

    // Adding bookmarks and drawing TOC entries
    private static float AddBookmark(PdfPage page, PdfPage toc, string content, float currentY)
    {
        // Add a new bookmark to the document with the given title
        PdfBookmark bookmark = document.Bookmarks.Add(content);

        // Draw the TOC entry text on the TOC page and get the updated Y-position
        float newY = AddTableOfContent(page, toc, content, new PointF(0, currentY));

        // Create a named destination pointing to the specified page and location
        PdfNamedDestination namedDestination = new PdfNamedDestination(content)
        {
            Destination = new PdfDestination(page, new PointF(0, currentY))
            {
                Mode = PdfDestinationMode.FitToPage // Ensures the destination fits the entire page in view
            }
        };

        // Add the named destination to the document's collection
        document.NamedDestinationCollection.Add(namedDestination);

        // Link the bookmark to the named destination
        bookmark.NamedDestination = namedDestination;

        // Return the updated Y-position for the next TOC entry
        return newY;
    }

    //Draws a TOC entry on the specified page, adds the corresponding page number, and creates a clickable link that navigates to the target content page.
    private static float AddTableOfContent(PdfPage page, PdfPage toc, string content, PointF point)
    {
        // Define the width available for the TOC entry text
        float textWidth = toc.Graphics.ClientSize.Width - 60;

        // Define the bounds where the TOC entry will be drawn
        RectangleF textBounds = new RectangleF(point.X, point.Y, textWidth, 100);

        // Create a text element for the TOC entry
        PdfTextElement element = new PdfTextElement(content, font, PdfBrushes.Blue);

        // Set layout format to fit within the page and allow pagination if needed
        PdfLayoutFormat format = new PdfLayoutFormat
        {
            Break = PdfLayoutBreakType.FitPage,
            Layout = PdfLayoutType.Paginate
        };

        // Draw the TOC entry text and get the layout result
        PdfLayoutResult result = element.Draw(toc, textBounds, format);

        // Draw the corresponding page number on the right side of the TOC page
        string pageNum = (document.Pages.IndexOf(page) + 1).ToString();
        PdfTextElement pageNumber = new PdfTextElement(pageNum, font, PdfBrushes.Black);
        pageNumber.Draw(toc, new PointF(toc.Graphics.ClientSize.Width - 40, point.Y));

        // Create a clickable link annotation over the TOC entry text
        RectangleF bounds = result.Bounds;
        bounds.Width = textWidth;

        PdfDocumentLinkAnnotation documentLinkAnnotation = new PdfDocumentLinkAnnotation(bounds)
        {
            AnnotationFlags = PdfAnnotationFlags.NoRotate,
            Text = content,
            Color = Color.Transparent, // Invisible clickable area
            Destination = new PdfDestination(page),
            Border = new PdfAnnotationBorder(0) // No visible border
        };

        // Set the destination location on the target page
        documentLinkAnnotation.Destination.Location = point;

        // Add the link annotation to the TOC page
        toc.Annotations.Add(documentLinkAnnotation);

        // Return the updated Y-position for the next TOC entry
        return result.Bounds.Bottom + 10;
    }
}
