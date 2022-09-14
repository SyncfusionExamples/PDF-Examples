using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compression_in_monochrome_images
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a PDF document.
            PdfDocument pdfDocument = new PdfDocument();

            //Add a page.
            PdfPage page = pdfDocument.Pages.Add();

            //Load single frame TIFF image.
            PdfBitmap tiffImage = PdfImage.FromFile("../../Data/image.tiff") as PdfBitmap;

            //Set encode type.
            tiffImage.Encoding = EncodingType.JBIG2;

            //Draw an image.
            page.Graphics.DrawImage(tiffImage, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);

            //Save and close the document.
            pdfDocument.Save("Sample.pdf");
            pdfDocument.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("Sample.pdf");
        }
    }
}
