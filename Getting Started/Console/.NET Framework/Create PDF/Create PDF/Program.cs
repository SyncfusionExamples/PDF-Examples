using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_PDF {
    internal class Program {
        static void Main(string[] args) {
            //Create a new PDF document. 
            using (PdfDocument document = new PdfDocument()) {
                //Add a page to the document.
                PdfPage page = document.Pages.Add();
                //Create PDF graphics for a page.
                PdfGraphics graphics = page.Graphics;
                //Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                //Draw the text.
                graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
                //Save the document.
                document.Save("Output.pdf");
            }
        }
    }
}
