using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

namespace Header_Management_in_PDF_Sections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Create a new PDF document.
            using (PdfDocument document = new PdfDocument())
            {
                // Define the font for the header
                PdfFont headerfont = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

                // Create the first section with headers
                PdfSection sectionWithHeaders = document.Sections.Add();
                // Apply header to this section
                sectionWithHeaders.Template.Top = CreateHeaderTemplate(headerfont);

                // Add 5 pages in the first section
                for (int i = 0; i < 5; i++)
                {
                    PdfPage page = sectionWithHeaders.Pages.Add();
                    DrawContentOnPage(page, $"Content for page {i + 1} in section with headers");
                }

                // Create the second section without headers
                PdfSection sectionWithoutHeaders = document.Sections.Add();

                // Add 5 pages in the second section
                for (int i = 0; i < 5; i++)
                {
                    PdfPage page = sectionWithoutHeaders.Pages.Add();
                    DrawContentOnPage(page, $"Content for page {i + 6} in section without headers");
                }

                //Save the PDF document
                document.Save(Path.GetFullPath(@"Output/Output.pdf"));
            }

        private static PdfPageTemplateElement CreateHeaderTemplate(PdfFont headerfont)
        {
            RectangleF rect = new RectangleF(0, 0, 500, 50); // Adjust width and height as needed
            PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            header.Graphics.DrawString("Header Text", headerfont, PdfBrushes.Black, new PointF(0, 0)); // Customize your header here
            return header;
        }

        private static void DrawContentOnPage(PdfPage page, string content)
        {
            PdfGraphics graphics = page.Graphics;
            // You can customize the positioning and styling of your content
            graphics.DrawString(content, new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new PointF(0, 100));
        }
    }
}
