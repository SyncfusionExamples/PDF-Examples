using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replace_image_in_an_existing_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document.
            PdfLoadedDocument document = new PdfLoadedDocument(@"../../Data/Input.pdf");

            //Create an image instance.
            PdfBitmap image = new PdfBitmap(@"../../Data/Autumn Leaves.jpg");

            //Replace the first image in the page.
            document.Pages[0].ReplaceImage(0, image);

            //Save the document.
            document.Save("Output.pdf");

            //Close the document.
            document.Close(true);
        }
    }
}
