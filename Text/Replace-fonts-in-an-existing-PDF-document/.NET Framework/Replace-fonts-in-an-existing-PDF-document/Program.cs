using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replace_fonts_in_an_existing_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the existing PDF document. 
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../Data/Input.pdf");

            //Replace font.
            loadedDocument.UsedFonts[0].Replace(new PdfStandardFont(PdfFontFamily.Courier, 12));

            //Save the document.
            loadedDocument.Save("Output.pdf");

            //Close the document. 
            loadedDocument.Close(true);
        }
    }
}
