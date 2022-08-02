// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

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

//Draw the hyperlink in loaded page graphics.
textLink.DrawTextWebLink(loadedPage.Graphics, new PointF(10, 40));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
