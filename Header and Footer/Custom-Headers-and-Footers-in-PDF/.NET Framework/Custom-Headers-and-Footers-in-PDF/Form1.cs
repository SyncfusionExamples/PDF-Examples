using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace Custom_Headers_and_Footers_in_PDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
             // Create a new PDF document
             PdfDocument document = new PdfDocument();

     // Paragraph content to display on each page
            string paragraph = @"The page tree serves as the root of the document. In the simplest case, it is just a list of the pages in the document. Each page is defined as an independent entity with metadata (e.g., page dimensions) and a reference to its resources and content, which are defined separately. Together, the page tree and page objects create the “paper” that composes the document.
Resources are objects that are required to render a page. For example, a single font is typically used across several pages, so storing the font information in an external resource is much more efficient. A content object defines the text and graphics that actually show up on the page. Together, content objects and resources define the appearance of an individual page.
Finally, the document’s catalog tells applications where to start reading the document. Often, this is just a pointer to the root page tree.";

            // ===== Section 1 =====
            AddSectionWithHeaderFooter(document, "Header - Section 1", "Footer - Section 1", 1, paragraph);

            // ===== Section 2 =====
            AddSectionWithHeaderFooter(document, "Header - Section 2", "Footer - Section 2", 1, paragraph);

            // Save and close the document
            document.Save("Output.pdf");
            // Close and dispose of the PDF document
            document.Close(true);
        }

        // Adds a specified number of pages to the document, each with a unique header, footer, and paragraph content.
        static void AddSectionWithHeaderFooter(PdfDocument document, string headerText, string footerText, int numberOfPages, string pageContent)
        {
            // Define fonts and brush
            PdfFont headerFooterFont = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);
            PdfFont bodyFont = new PdfStandardFont(PdfFontFamily.Helvetica, 11);
            PdfBrush brush = PdfBrushes.Black;

            for (int i = 0; i < numberOfPages; i++)
            {
                // Add a new page
                PdfPage page = document.Pages.Add();

                // Draw Header
                page.Graphics.DrawString(headerText, headerFooterFont, brush, new PointF(10, 10));

                // Draw Footer
                float footerY = page.GetClientSize().Height - 20;
                page.Graphics.DrawString(footerText, headerFooterFont, brush, new PointF(10, footerY));

                // Draw the paragraph content using PdfTextElement for proper layout and wrapping
                RectangleF contentBounds = new RectangleF(20, 40, page.GetClientSize().Width - 40, page.GetClientSize().Height - 80);
                PdfTextElement textElement = new PdfTextElement(pageContent, bodyFont, brush)
                {
                    StringFormat = new PdfStringFormat()
                    {
                        Alignment = PdfTextAlignment.Left,
                        LineSpacing = 5f
                    }
                };
                // Draw the paragraph text within the defined rectangle area on the page
                textElement.Draw(page, contentBounds);
            }
        }

    }
}
