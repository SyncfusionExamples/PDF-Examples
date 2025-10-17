using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
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

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
