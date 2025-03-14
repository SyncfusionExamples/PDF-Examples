// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Lists;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Sets document title.
document.DocumentInformation.Title = "List";

//Add a new page to the document.
PdfPage page = document.Pages.Add();

//Create graphics for PDF page. 
PdfGraphics graphics = page.Graphics;

//Get the page graphics size. 
SizeF size = page.Graphics.ClientSize;

//Load the TrueType font from the local *.ttf file.
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/Arial.ttf"), FileMode.Open, FileAccess.Read);
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

//Draw text in PDF page. 
graphics.DrawString("List:", font, PdfBrushes.Blue, new PointF(10, 0));

string[] products = { "Tools", "Grid", "Chart", "Edit", "Diagram", "XlsIO", "Grouping", "Calculate", "PDF", "HTMLUI", "DocIO" };

//Create string format with line spacing. 
PdfStringFormat format = new PdfStringFormat();
format.LineSpacing = 10f;

//Initialize new structure element with tag type List.
PdfStructureElement listElement = new PdfStructureElement(PdfTagType.List);

//Create ordered list.
PdfOrderedList pdfList = new PdfOrderedList();

//Adding tag for list element.
pdfList.PdfTag = listElement;

//Set the brush and indent to ordered list. 
pdfList.Marker.Brush = PdfBrushes.Black;
pdfList.Indent = 20;

//Set format for sub list.
pdfList.Font = font;

//Assign the string format. 
pdfList.StringFormat = format;

for (int i = 0; i < products.Length; i++)
{
    //Add items to ordered list. 
    pdfList.Items.Add(string.Concat("Essential ", products[i]));

    //Adding tag for the list item.
    pdfList.Items[i].PdfTag = new PdfStructureElement(PdfTagType.ListItem);
}

//Draw the list.
pdfList.Draw(page, new RectangleF(0, 20, size.Width, size.Height));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
fontStream.Dispose();
document.Close(true);
