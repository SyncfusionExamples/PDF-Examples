using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace HTML_Header_and_Footer {
    internal class Program {
        static void Main(string[] args) {
            //Initialize HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            //Initialize blink converter settings.
            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
			//Set the Blink viewport size.
            blinkConverterSettings.ViewPortSize = new Size(1280, 0);
            //Reade the html header and footer text from the html file or you can set html string also.
            string headerTemplate = File.ReadAllText(@"Data\header.html");
            string footerTemplate = File.ReadAllText(@"Data\footer.html");
            //Set the html margin-top value based on the html header height and margin-top value.
            blinkConverterSettings.Margin.Top = 70;
            //Set the html margin-bottom value based on the html footer height and margin-bottom value.
            blinkConverterSettings.Margin.Bottom = 40;
            //Set the custom HTML header to add at the top of each page.
            blinkConverterSettings.HtmlHeader = headerTemplate;
            //Set the custom HTML footer to add at the bottom of each page.
            blinkConverterSettings.HtmlFooter = footerTemplate;
            //Assign Blink converter settings to the HTML converter.
            htmlConverter.ConverterSettings = blinkConverterSettings;
            //Convert the URL to a PDF document.
            PdfDocument document = htmlConverter.Convert("https://www.syncfusion.com");
            //Save the PDF document 
            document.Save(Path.GetFullPath(@"Output/Output.pdf"));
            //Close the document.
            document.Close(true);
        }
    }
}