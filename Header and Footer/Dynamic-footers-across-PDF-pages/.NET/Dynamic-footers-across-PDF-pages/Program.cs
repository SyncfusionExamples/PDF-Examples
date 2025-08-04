using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Create a new PDF document
        PdfDocument document = new PdfDocument();

        // Add a section with space at the bottom for the footer
        PdfSection section1 = document.Sections.Add();
        section1.PageSettings.Margins.Bottom = 30;

        // Subscribe to the PageAdded event to add dynamic footer on each new page
        section1.PageAdded += (sender, e) => PageAddedHandler(sender, e, 1);

        // Add the first page (the rest will be added with page overflow)
        section1.Pages.Add();

        // Prepare the content font and brush
        PdfFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 18);
        PdfBrush contentBrush = new PdfSolidBrush(Color.Black);

        // Define formatting for the main content
        PdfStringFormat format = new PdfStringFormat()
        {
            ParagraphIndent = 35f,
            LineSpacing = 20f
        };
        // Instructional content (long enough to require multiple pages)
        string overflowText =
@"Creating PDF documentation programmatically with Syncfusion .NET libraries enables automation of reports, invoices, and technical manuals.
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

        // Draw text with automatic pagination (triggers PageAdded for each extra page)
        var textElement = new PdfTextElement(overflowText, contentFont, PdfPens.Black, contentBrush,format);
        PdfLayoutFormat layoutFormat = new PdfLayoutFormat
        {
            Layout = PdfLayoutType.Paginate,
            PaginateBounds = new RectangleF(0, 0, section1.Pages[0].GetClientSize().Width, section1.Pages[0].GetClientSize().Height - 30)
        };
        textElement.Draw(
            section1.Pages[0],
            new RectangleF(0, 0, section1.Pages[0].GetClientSize().Width, section1.Pages[0].GetClientSize().Height - 30),
            layoutFormat
        );
        // Save and close
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
        {
            document.Save(outputFileStream);
        }
        document.Close(true);
    }
    // Handles the PageAdded event to draw a dynamic footer on each page.
    static void PageAddedHandler(object sender, PageAddedEventArgs e, int sectionNumber)
    {
        PdfPage page = e.Page;
        int currentPage = page.Section.Pages.IndexOf(page) + 1;

        // Generate a human-readable timestamp for the footer
        string timestamp = DateTime.Now.ToString("'Date:' yyyy-MM-dd 'Time:' HH:mm:ss");
        string footerText = $"Section {sectionNumber} - Page {currentPage} - {timestamp}";

        // Draw footer on the current page
        page.Graphics.DrawString(
            footerText,
            new PdfStandardFont(PdfFontFamily.Helvetica, 12),
            new PdfSolidBrush(Color.Black),
            new PointF(10, page.GetClientSize().Height - 30)
        );
    }
}
