//Initialize HTML to PDF converter.
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//Initialize blink converter settings. 
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
//Set the Blink viewport size.
blinkConverterSettings.ViewPortSize = new Size(1280, 0);
//Set the html margin-top value based on the html header height and margin-top value.
blinkConverterSettings.Margin.Top = 70;
//Set the html margin-bottom value based on the html footer height and margin-bottom value.
blinkConverterSettings.Margin.Bottom = 40;
//Set the custom HTML header to add at the top of each page.
blinkConverterSettings.HtmlHeader = " <div style=\"background-color: blue; -webkit-print-color-adjust: exact; margin-left: 40px; font-size: 10px;\">HTML Header</div>";
//Set the custom HTML footer to add at the bottom of each page.
blinkConverterSettings.HtmlFooter = " <div style=\"background-color: blue; -webkit-print-color-adjust: exact;margin-left: 40px; font-size: 10px;\">HTML Footer</div>";
//Assign Blink converter settings to the HTML converter.
htmlConverter.ConverterSettings = blinkConverterSettings;
//Convert the URL to a PDF document.
PdfDocument document = htmlConverter.Convert("<div>Hello World</div>",string.Empty);

//Create a filestream.
FileStream fileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite);
//Save and close a PDF document.
document.Save(fileStream);
document.Close(true);