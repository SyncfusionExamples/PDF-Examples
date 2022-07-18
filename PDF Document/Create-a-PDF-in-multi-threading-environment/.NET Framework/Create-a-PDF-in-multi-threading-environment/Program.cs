using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_a_PDF_in_multi_threading_environment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set the range. 
            IEnumerable<int> works = Enumerable.Range(0, 100);

            //Call the GeneratePDF method to create PDF in multi-threading environment. 
            Parallel.ForEach(works, index => GeneratePDF(index));
        }

        private static void GeneratePDF(int index)
        {
            //Enable the thread safe in PDF document.
            PdfDocument.EnableThreadSafe = true;

            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text.
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

            string name = Guid.NewGuid().ToString();

            //Save the document.
            document.Save(name + ".pdf");

            //Close the document.
            document.Close(true);
            
        }
    }
}
