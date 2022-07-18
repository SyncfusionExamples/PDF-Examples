using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embed_all_fonts_in_an_existing_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load an existing document.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../Data/input.pdf");

            //Embed all the non-embedded fonts.
            if (loadedDocument.IsAllFontsEmbedded == false)
            {
               loadedDocument.EmbedFonts();
            }

            //Save the document.
            loadedDocument.Save("../../Data/Output.pdf");

            //Close the document.
            loadedDocument.Close(true);
        }
    }
}
