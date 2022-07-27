using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_RTF_text_in_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page.
            PdfPage page = document.Pages.Add();

            //Get the page size. 
            SizeF bounds = page.GetClientSize();

            //Read RTF document.
            StreamReader reader = new StreamReader(@"../../Data/Essential PDF.rtf", Encoding.ASCII);
            string text = reader.ReadToEnd();
            reader.Close();

            //Convert it to Metafile.
            PdfMetafile imageMetafile = (PdfMetafile)PdfImage.FromRtf(text, bounds.Width, PdfImageType.Metafile);
            PdfMetafileLayoutFormat format = new PdfMetafileLayoutFormat();

            //Allow text to flow multiple pages without any break.
            format.SplitTextLines = true;

            //Draws image.
            imageMetafile.Draw(page, 0, 0, format);

            //Save the document.
            document.Save("Output.pdf");

            //Close the document. 
            document.Close(true);
        }
    }
}
