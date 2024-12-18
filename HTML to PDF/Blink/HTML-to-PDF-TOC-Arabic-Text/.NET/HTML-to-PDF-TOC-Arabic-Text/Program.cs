﻿using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.HtmlToPdf;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
//Initialize blink converter settings. 
BlinkConverterSettings settings = new BlinkConverterSettings();
//Set enable table of contents.
settings.EnableToc = true;
//Set the style for level 1(H1) items in table of contents.
HtmlToPdfTocStyle tocstyleH1 = new HtmlToPdfTocStyle();
// Load the Arabic font from a file
PdfFont arabicFont = new PdfTrueTypeFont(@"Data/arial-unicode-ms.ttf", 10, PdfFontStyle.Regular);
// Set the TOC style with the Arabic font
tocstyleH1.Font = arabicFont;
//tocstyleH1.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10, PdfFontStyle.Regular);
tocstyleH1.BackgroundColor = new PdfSolidBrush(new PdfColor(Color.FromArgb(68, 114, 196)));
tocstyleH1.ForeColor = PdfBrushes.White;
tocstyleH1.Padding = new PdfPaddings(5, 5, 3, 3);
settings.Toc.SetItemStyle(1, tocstyleH1);
settings.Toc.SetItemStyle(2, tocstyleH1);
settings.Toc.SetItemStyle(3, tocstyleH1);
settings.Toc.SetItemStyle(4, tocstyleH1);
//Assign Blink converter settings to HTML converter.
htmlConverter.ConverterSettings = settings;
//Convert HTML to PDF document. 
PdfDocument document = htmlConverter.Convert(Path.GetFullPath(@"Data/input1.html"));
//Create file stream to save the PDF document. 
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/HTML-to-PDF.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document 
    document.Save(fileStream);
}
//Close the PDF document 
document.Close(true);
