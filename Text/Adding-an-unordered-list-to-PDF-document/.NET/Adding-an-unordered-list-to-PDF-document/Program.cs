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

//Get the size. 
SizeF size = page.Graphics.ClientSize;

//Create an unordered list.
PdfUnorderedList list = new PdfUnorderedList();

//Set the marker style.
list.Marker.Style = PdfUnorderedMarkerStyle.Disk;

//Create font and write title.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Regular);

//Create string format.
PdfStringFormat format = new PdfStringFormat();
format.LineSpacing = 10f;

//Format list.
list.Font = font;
list.StringFormat = format;

//Set list indent.
list.Indent = 10;

//Add items to the list.
list.Items.Add("PDF");
list.Items.Add("XlsIO");
list.Items.Add("DocIO");
list.Items.Add("PPT");

//Set text indent.
list.TextIndent = 10;

//Draw list.
list.Draw(page, new RectangleF(0, 10, size.Width, size.Height));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
