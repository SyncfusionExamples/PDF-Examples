// Create a new instance of PdfDocument class.
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Lists;
using Syncfusion.Drawing;

PdfDocument document = new PdfDocument();
// Add a new page to the document.
PdfPage page = document.Pages.Add();

// Create PDF graphics for the page.
SizeF size = page.Graphics.ClientSize;
PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10, PdfFontStyle.Italic);

string[] products = { "Tools", "Grid", "Chart", "DocIO" };

// Create Ordered list
PdfOrderedList pdfList = new PdfOrderedList();
pdfList.Marker.Brush = PdfBrushes.Black;
pdfList.Indent = 20;
pdfList.Font = font;

PdfStringFormat format = new PdfStringFormat();
format.LineSpacing = 10f;
pdfList.StringFormat = format;

foreach (string s in products)
{
    PdfListItem item = new PdfListItem($"Essential {s}");

    // Add sub-list for the "Tools" product
    if (s == "Tools")
    {
        PdfOrderedList subList = new PdfOrderedList();
        subList.Indent = pdfList.Indent + 30;
        subList.Marker.Brush = PdfBrushes.Blue;
        subList.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 9);

        string[] tools = { "Syntax Editor", "DropDown", "Calculator" };
        foreach (string tool in tools)
        {
            subList.Items.Add(tool);
        }

        item.SubList = subList;
    }

    pdfList.Items.Add(item);
}

pdfList.Draw(page, new RectangleF(0, 20, size.Width, size.Height));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
