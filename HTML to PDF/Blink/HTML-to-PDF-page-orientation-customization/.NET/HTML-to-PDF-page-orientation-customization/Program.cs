using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace HTML_to_PDF_page_orientation_customization {
    internal class Program {
        static void Main(string[] args) {
            //Initialize the HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            //Initialize blink converter settings. 
            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
            //Set the Orientation.
            blinkConverterSettings.Orientation = PdfPageOrientation.Landscape;
            //Assign Blink converter settings to HTML converter.
            htmlConverter.ConverterSettings = blinkConverterSettings;
            //Convert URL to PDF document.  
            PdfDocument document = htmlConverter.Convert("https://www.google.com");

            //Create a file stream.
            FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/HTML-to-PDF.pdf"), FileMode.Create, FileAccess.ReadWrite);
            //Save a PDF document to a file stream.
            document.Save(fileStream);
            //Close the document.
            document.Close(true);
        }
    }
}