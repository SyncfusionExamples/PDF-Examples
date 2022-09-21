using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_a_PDFX1A_conformance_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new document with PDF/x standard.
            PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_X1A2001);

            //Add a page.
            PdfPage page = document.Pages.Add();

            //Set the colorspace.
            document.ColorSpace = PdfColorSpace.CMYK;

            //Create Pdf graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Create a solid brush.
            PdfBrush brush = new PdfSolidBrush(Color.Black);
            Font font = new Font("Arial", 20f, FontStyle.Regular);

            //Set the font.
            PdfFont pdfFont = new PdfTrueTypeFont(font, FontStyle.Regular, 12, false, true);

            //Draw the text.
            graphics.DrawString("Hello world!", pdfFont, brush, new PointF(20, 20));

            //Save and close the document.
            document.Save("Output.pdf");
            document.Close(true);
        }
    }
}
