using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace HTML_to_PDF_rotate_page {
    internal class Program {
        static void Main(string[] args) {
            //Initialize the HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            //Initialize blink converter settings. 
            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
            //Set the page rotate.
            blinkConverterSettings.PageRotateAngle = PdfPageRotateAngle.RotateAngle90;
            //Assign Blink converter settings to the HTML converter.
            htmlConverter.ConverterSettings = blinkConverterSettings;
            //Convert URL to PDF document.  
            PdfDocument document = htmlConverter.Convert("https://www.google.com");

            //Save the PDF document 
            document.Save(Path.GetFullPath(@"Output/Output.pdf"));
            //Close the document.
            document.Close(true);
        }
    }
}