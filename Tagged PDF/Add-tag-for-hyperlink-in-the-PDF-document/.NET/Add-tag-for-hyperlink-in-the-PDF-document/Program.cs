// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Set the document information title. 
document.DocumentInformation.Title = "Link";

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Creates new PDF structure element with tag type link.
PdfStructureElement linkStructureElement = new PdfStructureElement(PdfTagType.Link);

//Create the font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12f);

//Create the text web link.
PdfTextWebLink textLink = new PdfTextWebLink();

//Adding tag to text web link.
textLink.PdfTag = linkStructureElement;

//Set the hyperlink.
textLink.Url = "http://www.syncfusion.com";

//Set the link text.
textLink.Text = "Syncfusion .NET components and controls";

//Set the font.
textLink.Font = font;

//Set the brush. 
textLink.Brush = PdfBrushes.Blue;

//Draw the hyperlink in PDF page
textLink.DrawTextWebLink(page, new PointF(10, 40));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
