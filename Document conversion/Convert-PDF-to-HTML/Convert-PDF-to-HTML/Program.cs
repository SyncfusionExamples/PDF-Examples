using Syncfusion.Pdf.Parsing;
using Syncfusion.PdfToHtmlConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_PDF_to_HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initializing PDF to HTML converter.
            PdfToHtmlConverter converter = new PdfToHtmlConverter();
            
            //Initializing and applying PDF to HTML converter settings.
            PdfToHtmlConverterSettings setting = new PdfToHtmlConverterSettings();
            setting.IsFrame = false;
            setting.AbsolutePositioning = false;
            converter.Settings = setting;
            
            //Loading the input PDF document.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../Data/Barcode.pdf");
            
            //Converting PDF to HTML file.
            converter.Convert("../../Data/Barcode.pdf", "Output.html", loadedDocument.Pages.Count);

            //Close the PDF document. 
            loadedDocument.Close(true);
        }
    }
}
