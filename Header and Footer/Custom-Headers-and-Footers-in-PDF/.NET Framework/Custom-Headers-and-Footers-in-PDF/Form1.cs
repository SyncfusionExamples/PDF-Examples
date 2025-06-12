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
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            PdfBrush brush = new PdfSolidBrush(Color.Black);

            // Paragraph content to display on each page
            string paragraph = @"The page tree serves as the root of the document. In the simplest case, it is just a list of the pages in the document. Each page is defined as an independent entity with metadata (e.g., page dimensions) and a reference to its resources and content, which are defined separately. Together, the page tree and page objects create the “paper” that composes the document.

        Resources are objects that are required to render a page. For example, a single font is typically used across several pages, so storing the font information in an external resource is much more efficient. A content object defines the text and graphics that actually show up on the page. Together, content objects and resources define the appearance of an individual page.

        Finally, the document’s catalog tells applications where to start reading the document. Often, this is just a pointer to the root page tree.";

            // Create 3 pages
            for (int i = 0; i < 3; i++)
            {
                PdfPage page = document.Pages.Add();

                // Header
                string headerText = $"Header for Page - {i + 1}";
                page.Graphics.DrawString(headerText, font, brush, new PointF(10, 10));

                // Footer
                string footerText = $"Footer for Page - {i + 1}";
                page.Graphics.DrawString(footerText, font, brush, new PointF(10, page.GetClientSize().Height - 30));

                // Draw paragraph content with left alignment
                PdfTextElement textElement = new PdfTextElement(paragraph, font, brush)
                {
                    StringFormat = new PdfStringFormat()
                    {
                        Alignment = PdfTextAlignment.Left,
                        LineSpacing = 5f
                    }
                };

                RectangleF contentBounds = new RectangleF(20, 100, page.GetClientSize().Width - 80, page.GetClientSize().Height - 150);
                textElement.Draw(page, contentBounds);
            }

            // Save the document
            document.Save("Output.pdf");
            // Close the PDF document
            document.Close(true);
        }

    }
}
