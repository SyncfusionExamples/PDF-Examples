// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Creates new PDF document.
PdfDocument document = new PdfDocument();

//Set true to auto tag all elements in document.
document.AutoTag = true;

//Set the document information title. 
document.DocumentInformation.Title = "AutoTag";

//Add a new page to the document.
PdfPage page = document.Pages.Add();

//Creates new text element.
PdfTextElement element = new PdfTextElement("This is paragraph ONE.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));

//Set the brush for text element. 
element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));

//Draw the text element in PDF page.  
element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 200));

//Creates new text element.
PdfTextElement element1 = new PdfTextElement("This is paragraph TWO.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));

//Set the brush for text element. 
element1.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));

//Draw the next element in PDF page. 
element1.Draw(page, new RectangleF(0, 50, page.Graphics.ClientSize.Width / 2, 200));

//Creates new text element.
PdfTextElement element2 = new PdfTextElement("This is paragraph THREE.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));

//Set the brush for text element. 
element2.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));

//Draw the next element in PDF page. 
element2.Draw(page.Graphics, new PointF(0, 100));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);



