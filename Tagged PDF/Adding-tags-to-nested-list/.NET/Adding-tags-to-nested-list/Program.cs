using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Lists;

// Create a new PDF document
PdfDocument document = new PdfDocument();

// Set the document title
document.DocumentInformation.Title = "Nested List";

// Add a new page to the PDF
PdfPage page = document.Pages.Add();
PdfGraphics graphics = page.Graphics;
SizeF size = page.Graphics.ClientSize;

//Get stream from the font file. 
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/Arial.ttf"), FileMode.Open, FileAccess.Read);
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

// Draw the title on the PDF
graphics.DrawString("Nested Ordered List:", font, PdfBrushes.Blue, new PointF(10, 0));

// Create a string format for line spacing of list items
PdfStringFormat format = new PdfStringFormat();
format.LineSpacing = 10f;

// Create the main list structure element with a List tag for accessibility
PdfStructureElement mainListElement = new PdfStructureElement(PdfTagType.List);

// Initialize the main ordered list
PdfOrderedList mainList = new PdfOrderedList
{
    PdfTag = mainListElement,
    Marker = { Brush = PdfBrushes.Black },
    Indent = 20,
    Font = font,
    StringFormat = format
};

// Add items to the main list and tag each item for accessibility
string[] mainItems = { "Essential Tools", "Essential PDF", "Essential XlsIO" };
for (int i = 0; i < mainItems.Length; i++)
{
    mainList.Items.Add(mainItems[i]);
    mainList.Items[i].PdfTag = new PdfStructureElement(PdfTagType.ListItem);
}

// Create a sublist with accessibility tags
PdfStructureElement subListElement = new PdfStructureElement(PdfTagType.List);
PdfOrderedList subList = new PdfOrderedList
{
    PdfTag = subListElement,
    Marker = { Brush = PdfBrushes.Black },
    Indent = 20,
    Font = font,
    StringFormat = format
};

// Add items to the sublist and tag each item for accessibility
string[] subItems = { "Create PDF", "Modify PDF", "Secure PDF", "Compress PDF" };
for (int i = 0; i < subItems.Length; i++)
{
    subList.Items.Add(subItems[i]);
    subList.Items[i].PdfTag = new PdfStructureElement(PdfTagType.ListItem);
}

// Nest the sublist under the second item of the main list
mainList.Items[1].SubList = subList;

// Draw the main list, which includes the nested sublist, on the PDF
mainList.Draw(page, new RectangleF(0, 30, size.Width, size.Height));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);