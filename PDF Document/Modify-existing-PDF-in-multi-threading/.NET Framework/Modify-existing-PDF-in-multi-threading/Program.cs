using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modify_existing_PDF_in_multi_threading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set the range. 
            IEnumerable<int> works = Enumerable.Range(0, 100);

            //Call ModifyPDF method to modify the existing PDF document in multi-theading environment. 
            Parallel.ForEach(works, index => ModifyPDF(index));

        }

        private static void ModifyPDF(int index)
        {
            //Enable the thread safe in PDF document.
            PdfDocument.EnableThreadSafe = true;

            //Load a PDF document.
            PdfLoadedDocument doc = new PdfLoadedDocument("../../Data/Input.pdf");

            //Get first page from document.
            PdfLoadedPage page = doc.Pages[0] as PdfLoadedPage;

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text.
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

            string name = Guid.NewGuid().ToString();

            //Save the document.
            doc.Save(name + ".pdf");

            //Close the document.
            doc.Close(true);
        }
    }
}
