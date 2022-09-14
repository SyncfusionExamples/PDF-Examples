
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_HTML_to_PDF_with_PDFA_conformance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

            //IE Converter settings.
            IEConverterSettings converterSettings = new IEConverterSettings();

            //PDFA1B conformance.
            converterSettings.IsPDFA1B = true;

            //Set converter settings. 
            htmlConverter.ConverterSettings = converterSettings;

            //Convert HTML to PDF document.
            PdfDocument document = htmlConverter.Convert("https://www.google.com");

            //Save and close the PDF document.
            document.Save("Output.pdf");
            document.Close(true);
        }
    }
}
