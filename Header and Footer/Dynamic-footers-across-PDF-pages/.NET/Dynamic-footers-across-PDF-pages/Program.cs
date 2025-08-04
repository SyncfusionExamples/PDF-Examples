using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
class Program
{
    public static PdfPage page;

    static void Main(string[] args)
    {
        // Create a new PDF document
        PdfDocument document = new PdfDocument();

        // Create a section and apply bottom margin for footers
        PdfSection section1 = document.Sections.Add();
        section1.PageSettings.Margins.Bottom = 30;

        // Attach a custom handler for the PageAdded event
        section1.PageAdded += (sender, e) => PageAddedHandler(sender, e, 1);

        // Add the first page to initialize pagination
        section1.Pages.Add();

        // Prepare font and brush for the main content
        PdfFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 18);
        PdfBrush contentBrush = new PdfSolidBrush(Color.Black);

        // Optionally, set up line spacing and paragraph styles
        PdfStringFormat format = new PdfStringFormat
        {
            ParagraphIndent = 35f,
            LineSpacing = 20f
        };
        // Get example instructional text related to PDF creation
        string overflowText = GetLongPdfGuideText();
        // Draw the instructional text using PdfTextElement, which handles pagination
        var textElement = new PdfTextElement(overflowText, contentFont, contentBrush);
        PdfLayoutFormat layoutFormat = new PdfLayoutFormat
        {
            Layout = PdfLayoutType.Paginate, // Enables pagination
            PaginateBounds = new RectangleF(0, 0, section1.Pages[0].GetClientSize().Width, section1.Pages[0].GetClientSize().Height - 30) // Leaves space for footer
        };

        var layoutResult = textElement.Draw(section1.Pages[0],
            new RectangleF(0, 0, section1.Pages[0].GetClientSize().Width, section1.Pages[0].GetClientSize().Height - 30), layoutFormat);
        //Create file stream.
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
        {
            //Save the PDF document to file stream.
            document.Save(outputFileStream);
        }
        //Close the document.
        document.Close(true);   
    }

    /// <summary>
    /// Handles the PageAdded event to draw a dynamic footer on each page.
    /// </summary>
    static void PageAddedHandler(object sender, PageAddedEventArgs e, int sectionNumber)
    {
        PdfPage page = e.Page;
        int currentPage = page.Section.Pages.IndexOf(page) + 1;

        // Generate a random alphanumeric code for added uniqueness in the footer
        string randomFooter = GenerateRandomFooterCode();

        string footerText = $"Section {sectionNumber} - Page {currentPage} - {randomFooter}";

        // Add the footer to the page
        DrawFooter(page, footerText);
    }

    /// <summary>
    /// Draws the footer text at the bottom of the specified page.
    /// </summary>
    static void DrawFooter(PdfPage page, string footerText)
    {
        page.Graphics.DrawString(
            footerText,
            new PdfStandardFont(PdfFontFamily.Helvetica, 12),
            new PdfSolidBrush(Color.Black),
            new PointF(10, page.GetClientSize().Height - 30)
        );
    }

    /// <summary>
    /// Generates a random 3-letter code with numbers for footer uniqueness.
    /// </summary>
    static string GenerateRandomFooterCode()
    {
        Random random = new Random();
        char[] letters = new char[3];
        for (int i = 0; i < 3; i++)
            letters[i] = (char)('A' + random.Next(26));
        return new string(letters) + random.Next(100, 1000).ToString();
    }

    /// <summary>
    /// Returns sample instructional text about PDF generation and features.
    /// </summary>
    static string GetLongPdfGuideText()
    {
        // This text simulates documentation for PDF feature usage
        return @"Creating PDF documentation programmatically with Syncfusion .NET libraries enables automation of reports, invoices, and technical manuals.

Key Features:
- Multi-page automatic content flow using pagination
- Support for rich text formatting: headers, bullets, and tables
- Insert images, tables, and charts seamlessly
- Add interactive elements: bookmarks, hyperlinks, and attachments
- Control layout: margins, page breaks, and dynamic footers

Usage Example:
This project demonstrates how to paginate multiple paragraphs of text describing PDF functionality. When the content exceeds a single page, Syncfusion’s PdfTextElement automatically creates new pages and triggers the PageAdded event. This allows you to attach custom footers, such as page numbers or custom codes, to each page for improved navigation and professional document appearance.

Adding dynamic footers is useful for:
- Section labeling in large documents
- Including secure or traceable codes for each page
- Ensuring readers always know their page context

Other advanced scenarios:
- Creating Table of Contents with page navigation
- Inserting named destinations for quick jumps
- Using graphics and interactive elements within the same document

Experiment by updating this program to add headers, watermarks, or section-based page numbers based on your specific requirements.

For more information, visit:
https://help.syncfusion.com/file-formats/pdf/working-with-text
https://help.syncfusion.com/file-formats/pdf/working-with-graphics

This concludes the instructional workflow for auto-paginated, footer-enhanced PDF generation in .NET.";
    }
}
