using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converting_the_URL_to_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

            //Convert HTML to PDF document.
            PdfDocument document = htmlConverter.Convert("https://www.google.com");

            //Save and close the PDF document.
            document.Save("Output.pdf");
            document.Close(true);
        }
    }
}
