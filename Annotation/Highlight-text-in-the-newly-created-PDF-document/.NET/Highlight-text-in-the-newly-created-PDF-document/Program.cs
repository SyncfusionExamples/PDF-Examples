// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Create a new page.
PdfPage page = document.Pages.Add();

//Get stream from the font file. 
FileStream fontStream = new FileStream(Path.GetFullPath("../../../Arial.ttf"), FileMode.Open, FileAccess.Read);

//Create PDF font. 
PdfFont pdfFont = new PdfTrueTypeFont(fontStream, 14);

//Create a new PDF brush.
PdfBrush pdfBrush = new PdfSolidBrush(Color.Black);

//Draw text in the new page.
page.Graphics.DrawString("Text Markup Annotation Demo", pdfFont, pdfBrush, new PointF(150, 10));

//Set markup text. 
string markupText = "Text Markup";

//Get the size of the given string.  
SizeF size = pdfFont.MeasureString(markupText);

//Draw text in the page. 
RectangleF rectangle = new RectangleF(175, 40, size.Width, size.Height);
page.Graphics.DrawString(markupText, pdfFont, pdfBrush, rectangle);

//Create a PDF text markup annotation.
PdfTextMarkupAnnotation markupAnnotation = new PdfTextMarkupAnnotation("Markup annotation", "Markup annotation with highlight style", markupText, new PointF(175, 40), pdfFont);

//Set the properties of text markup annotation. 
markupAnnotation.TextMarkupColor = new PdfColor(Color.BlueViolet);
markupAnnotation.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight;

//Add this annotation to a new page.
page.Annotations.Add(markupAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);