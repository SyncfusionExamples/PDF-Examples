using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converting_HTML_string_to_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

            //HTML string and base URL.
            string htmlText = "<html><body><img src=\"Syncfusion_logo.png\" alt=\"Syncfusion_logo\" width=\"200\" height=\"70\"><p> Hello World</p></body></html>";
            string baseUrl = Path.GetFullPath("../../../Image/");

            //Convert HTML to PDF document.
            PdfDocument document = htmlConverter.Convert(htmlText, baseUrl);

            //Save and close the PDF document.
            document.Save("Output.pdf");
            document.Close(true);
        }
    }
}
