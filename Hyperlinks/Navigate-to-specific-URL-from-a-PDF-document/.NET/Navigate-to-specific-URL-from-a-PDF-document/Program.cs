// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Create the font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12f);

//Create the Text Web Link.
PdfTextWebLink textLink = new PdfTextWebLink();

//Set the hyperlink.
textLink.Url = "http://www.syncfusion.com";

//Set the link text.
textLink.Text = "Syncfusion .NET components and controls";

//Set the font.
textLink.Font = font;

//Draw the hyperlink in PDF page.
textLink.DrawTextWebLink(page, new PointF(10, 40));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);