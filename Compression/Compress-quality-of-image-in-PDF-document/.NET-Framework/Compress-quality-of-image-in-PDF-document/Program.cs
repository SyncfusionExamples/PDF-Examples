using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compress_quality_of_image_in_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            PdfBitmap image = new PdfBitmap("../../Data/Image.png");

            //Reduce the quality of the image
            image.Quality = 50;

            image.Draw(page, new PointF(0, 0));

            //Save the document.
            document.Save("Output.pdf");

            //Close the document.
            document.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("Output.pdf");
        }
    }
}
