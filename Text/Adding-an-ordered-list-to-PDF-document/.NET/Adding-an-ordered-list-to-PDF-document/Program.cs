// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Lists;

//Create a new instance of PdfDocument class.
PdfDocument document = new PdfDocument();

//Add a new page to the document.
PdfPage page = document.Pages.Add();

//Create graphics for PDF page.
PdfGraphics graphics = page.Graphics;

//Get the size of the page graphics. 
SizeF size = page.Graphics.ClientSize;

//Create font.
PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10, PdfFontStyle.Italic);

string[] products = { "Tools", "Grid", "Chart", "Edit", "Diagram", "XlsIO", "Grouping", "Calculate", "PDF", "HTMLUI", "DocIO" };

//Create string format.
PdfStringFormat format = new PdfStringFormat();

//Set the line spacing for line spacing. 
format.LineSpacing = 10f;

//Create Ordered list.
PdfOrderedList pdfList = new PdfOrderedList();
pdfList.Marker.Brush = PdfBrushes.Black;
pdfList.Indent = 20;

//Set format for sub list.
pdfList.Font = font;

//Set string format for ordered list.
pdfList.StringFormat = format;

foreach (string s in products)
{
    //Add items.
    pdfList.Items.Add(string.Concat("Essential ", s));
}

//Draw ordered list to PDF document.
pdfList.Draw(page, new RectangleF(0, 20, size.Width, size.Height));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

