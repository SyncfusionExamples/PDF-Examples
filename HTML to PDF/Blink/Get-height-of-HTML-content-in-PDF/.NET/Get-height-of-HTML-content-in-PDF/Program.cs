// See https://aka.ms/new-console-template for more information

using Syncfusion.HtmlConverter;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

PdfLayoutResult layoutResult = null;

//Convert URL to PDF document. 
PdfDocument document = htmlConverter.Convert("https://www.syncfusion.com", out layoutResult);

//Draw the text at the end of HTML content.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 11);
document.Pages[document.Pages.Count - 1].Graphics.DrawString("End of HTML content", font, PdfBrushes.Red, new PointF(0, layoutResult.Bounds.Bottom));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../HTML-to-PDF.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
