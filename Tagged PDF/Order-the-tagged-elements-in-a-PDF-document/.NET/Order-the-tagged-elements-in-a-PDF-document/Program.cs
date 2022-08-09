// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Sets document title.
document.DocumentInformation.Title = "Order";

//Add a new page to the document.
PdfPage page = document.Pages.Add();

//Initialize the structure element with tag type paragraph.
PdfStructureElement structureElement = new PdfStructureElement(PdfTagType.Paragraph);

//Order the tag in third position.
structureElement.Order = 3;

//Create the text element. 
PdfTextElement element = new PdfTextElement("This is paragraph ONE.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));

//Set the text element brush. 
element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));

//Adding tag to the text element.
element.PdfTag = structureElement;

//Draw the text element. 
element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 200));

//Initialize the structure element with tag type paragraph.
PdfStructureElement paraStruct1 = new PdfStructureElement(PdfTagType.Paragraph);

//Order the tag in first position.
paraStruct1.Order = 1;

//Creates new text element.
PdfTextElement element1 = new PdfTextElement("This is paragraph TWO.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));

//Set the brush for text element. 
element1.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));

//Adding tag to the text element.
element1.PdfTag = paraStruct1;

//Draw text element in PDF page. 
element1.Draw(page, new RectangleF(0, 50, page.Graphics.ClientSize.Width / 2, 200));

//Initialize the structure element with tag type paragraph.
PdfStructureElement paraStruct2 = new PdfStructureElement(PdfTagType.Paragraph);

//Order the tag in second position.
paraStruct2.Order = 2;

//Creates new text element.
PdfTextElement element2 = new PdfTextElement("This is paragraph THREE.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));

element2.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));

//Adding tag to the text element.
element2.PdfTag = paraStruct2;

//Draw the next text element in PDF page. 
element2.Draw(page.Graphics, new PointF(0, 100));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
