using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Create a new PDF document.
        PdfDocument document = new PdfDocument();

        // Subscribe to the PageAdded event to add header and footer for every page.
        document.Pages.PageAdded += (sender, e) => PageAddedHandler(sender, e);

        // Define content font and brush for main text.
        PdfFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 18);
        PdfBrush contentBrush = new PdfSolidBrush(Color.Black);

        // Define the main instructional text.
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

        // Set the header and footer height 
        float headerHeight = 40f;
        float footerHeight = 30f;

        // Create a text element for automatic pagination.
        PdfTextElement textElement = new PdfTextElement(overflowText, contentFont, contentBrush);

        // Subscribe to the BeginPageLayout event to offset text on each new page below the header.
        textElement.BeginPageLayout += (sender, args) =>
        {
            // Always start content BELOW the header on every page.
            args.Bounds = new RectangleF(0, headerHeight, args.Page.GetClientSize().Width, args.Page.GetClientSize().Height - headerHeight - footerHeight);
        };

        // Add the first page.
        PdfPage firstPage = document.Pages.Add();

        // Start drawing content (pagination and event will handle rest).
        textElement.Draw(firstPage, new PointF(0, headerHeight));

        // Save and close the document.
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
        {
            document.Save(outputFileStream);
        }
        document.Close(true);
    }

    // Add header and footer to every page.
    static void PageAddedHandler(object sender, PageAddedEventArgs e)
    {
        PdfPage page = e.Page;
        int currentPage = page.Section.Pages.IndexOf(page) + 1;

        // Draw header at the top (within reserved header bounds).
        string headerText = $"This is the header - Page {currentPage}";
        page.Graphics.DrawString(
            headerText,
            new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold),
            new PdfSolidBrush(Color.DimGray),
            new PointF(10, 10) // Within header area
        );

        // Draw footer at the bottom (within reserved footer area).
        string timestamp = DateTime.Now.ToString("'Date:' yyyy-MM-dd 'Time:' HH:mm:ss");
        string footerText = $"Page {currentPage}    {timestamp}";
        page.Graphics.DrawString(
            footerText,
            new PdfStandardFont(PdfFontFamily.Helvetica, 12),
            new PdfSolidBrush(Color.Black),
            new PointF(10, page.GetClientSize().Height - 30)
        );
    }
}