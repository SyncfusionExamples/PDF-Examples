using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split_large_PDF_to_multiple_documents
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loads the PDF document.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../Data/Input.pdf");

            //Splits the document into multiple PDF documents. 
            loadedDocument.Split("split.pdf");

            //Closes the document.
            loadedDocument.Close(true);
        }
    }
}
