// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Creates new PDF document.
PdfDocument document = new PdfDocument();

//Set the document title.
document.DocumentInformation.Title = "PdfTextElement";

//Creates new page.
PdfPage page = document.Pages.Add();

//Initialize the structure element with tag type paragraph.
PdfStructureElement structureElement = new PdfStructureElement(PdfTagType.Paragraph);

//Represents the text that is exact replacement for PdfTextElement.
structureElement.ActualText = "Simple paragraph element";

string text = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";

//Initialize the PDF text element.
PdfTextElement element = new PdfTextElement(text);

//Adding tag to the text element.
element.PdfTag = structureElement;

//Creates font for the text element.
element.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);

//Create brush for the text element. 
element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));

//Draws text element. 
PdfLayoutResult result = element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width, 200));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
