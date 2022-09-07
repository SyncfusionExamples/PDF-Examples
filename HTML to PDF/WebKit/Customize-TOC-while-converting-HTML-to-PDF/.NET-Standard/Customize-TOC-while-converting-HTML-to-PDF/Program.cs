// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.HtmlToPdf;

//Initialize HTML to PDF converter with WebKit Rendering Engine.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Initialize HTML to PDF converter.
WebKitConverterSettings webKitSettings = new WebKitConverterSettings();

//Enable TOC.
webKitSettings.EnableToc = true;

//Set the style for level 1(H1) items in table of contents.
HtmlToPdfTocStyle tocstyleH1 = new HtmlToPdfTocStyle();
tocstyleH1.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10, PdfFontStyle.Regular);
tocstyleH1.BackgroundColor = new PdfSolidBrush(new PdfColor(Color.FromArgb(68, 114, 196)));
tocstyleH1.ForeColor = PdfBrushes.Pink;
tocstyleH1.Padding = new PdfPaddings(5, 5, 3, 3);

//Set style to TOC.
webKitSettings.Toc.SetItemStyle(1, tocstyleH1);

//Assign the WebKit settings.
htmlConverter.ConverterSettings = webKitSettings;

//Convert HTML to PDF.
PdfDocument document = htmlConverter.Convert(Path.GetFullPath("../../../input.html"));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
