using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adds a page.
    PdfPage page = document.Pages.Add();

    //Creates document bookmarks.
    PdfBookmark bookmark = document.Bookmarks.Add("Page 1");

    //Sets the destination page.
    bookmark.Destination = new PdfDestination(page);

    //Sets the destination location.
    bookmark.Destination.Location = new PointF(20, 20);

    //Sets the text style and color.
    bookmark.TextStyle = PdfTextStyle.Bold;
    bookmark.Color = Syncfusion.Drawing.Color.Red;

    //Set the font.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

    //Draw string in the first page with bookmark destination location. 
    page.Graphics.DrawString("Hello World!!!", font, PdfBrushes.Red, new PointF(20, 20));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}