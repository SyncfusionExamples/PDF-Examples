using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Set document information.
    document.DocumentInformation.Author = "Syncfusion";
    document.DocumentInformation.CreationDate = DateTime.Now;
    document.DocumentInformation.Creator = "Essential PDF";
    document.DocumentInformation.Keywords = "PDF";
    document.DocumentInformation.Subject = "Document information DEMO";
    document.DocumentInformation.Title = "Essential PDF Sample";

    //Add a page to the document.
    PdfPage page = document.Pages.Add();

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Set the font.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

    //Draw text to the page. 
    graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
