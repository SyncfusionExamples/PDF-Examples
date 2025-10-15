using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create the template from the page.
    PdfTemplate template = loadedPage.CreateTemplate();

    //Create a new PDF document.
    PdfDocument document = new PdfDocument();

    //Set the document margin.
    document.PageSettings.SetMargins(2);

    //Add the page.
    PdfPage page = document.Pages.Add();

    //Create the graphics.
    PdfGraphics graphics = page.Graphics;

    //Draw the template.
    graphics.DrawPdfTemplate(template, Syncfusion.Drawing.PointF.Empty, new Syncfusion.Drawing.SizeF(page.Size.Width / 2, page.Size.Height));

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
