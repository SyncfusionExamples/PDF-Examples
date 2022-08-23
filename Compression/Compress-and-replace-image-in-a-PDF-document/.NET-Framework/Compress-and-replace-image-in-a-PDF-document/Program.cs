using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compress_and_replace_image_in_a_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document with images. 
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../Data/Input.pdf");

            //Disable the incremental update.
            loadedDocument.FileStructure.IncrementalUpdate = false;

            //iterate all the pages to replace images.
            foreach (PdfPageBase page in loadedDocument.Pages)
            {
                //Extract the images from the document.
                Image[] extractedImages = page.ExtractImages();

                //Iterate all the image.
                for (int j = 0; j < extractedImages.Count(); j++)
                {
                    //Load the image from extracted images. 
                    PdfBitmap image = new PdfBitmap(extractedImages[j]);

                    //reduce the quality of the image.
                    image.Quality = 50;

                    //replace the compressed image with old image in the PDF document.
                    page.ReplaceImage(j, image);
                }
            }

            //Save and close the document.
            loadedDocument.Save("Output.pdf");
            loadedDocument.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("Output.pdf");
        }
    }
}
