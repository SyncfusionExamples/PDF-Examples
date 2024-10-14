using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Runtime.InteropServices;

namespace HTML_to_PDF_rotate_page {
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
            //Set the page rotate.
            blinkConverterSettings.PageRotateAngle = PdfPageRotateAngle.RotateAngle90;
            //Assign Blink converter settings to the HTML converter.
            htmlConverter.ConverterSettings = blinkConverterSettings;
            //Convert URL to PDF document.  
            PdfDocument document = htmlConverter.Convert("https://www.google.com");

            //Create file stream. 
            using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                //Save the PDF document 
                document.Save(fileStream);
            }
            //Close the document.
            document.Close(true);
        }
    }
}