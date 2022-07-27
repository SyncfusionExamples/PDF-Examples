using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_vector_image_in_a_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a PDF document.
            PdfDocument document = new PdfDocument();

            //Add pages to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Create the layout format.
            PdfMetafileLayoutFormat format = new PdfMetafileLayoutFormat();

            //Split text and image between pages.
            format.SplitImages = true;
            format.SplitTextLines = true;

            //Create a Metafile instance.
            PdfMetafile metaChart = new PdfMetafile("../../Data/MetaChart.emf");

            //Draw the Metafile in the page.
            metaChart.Draw(page, PointF.Empty, format);

            //Save the document.
            document.Save("Output.pdf");

            //Close the document.
            document.Close(true);
        }
    }
}
