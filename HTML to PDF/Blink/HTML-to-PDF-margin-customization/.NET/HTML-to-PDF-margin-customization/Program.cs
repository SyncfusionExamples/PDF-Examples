using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

namespace HTML_to_PDF_margin_customization {
    internal class Program {
        static void Main(string[] args) {
            //Initialize the HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            //Initialize blink converter settings. 
            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				blinkConverterSettings.CommandLineArguments.Add("--no-sandbox");
				blinkConverterSettings.CommandLineArguments.Add("--disable-setuid-sandbox");
			}
            //Set the margin.
            blinkConverterSettings.Margin.All = 50;
            //Assign Blink converter settings to HTML converter.
            htmlConverter.ConverterSettings = blinkConverterSettings;
            //Convert URL to PDF document.  
            PdfDocument document = htmlConverter.Convert("https://www.google.com");

            //Create a file stream.
            FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/HTML-to-PDF.pdf"), FileMode.Create, FileAccess.ReadWrite);
            //Save the PDF document to the file stream.
            document.Save(fileStream);
            //Close the document.
            document.Close(true);
        }
    }
}