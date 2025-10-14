using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adds a page.
    PdfPage page = document.Pages.Add();

    //Creates bookmark.
    PdfBookmark bookmark = document.Bookmarks.Add("Page 1");

    //Sets the destination page.
    bookmark.Destination = new PdfDestination(page);

    //Sets the destination location.
    bookmark.Destination.Location = new PointF(20, 20);

    //Adds the child bookmark.
    PdfBookmark childBookmark = bookmark.Insert(0, "heading 1");
    childBookmark.Destination = new PdfDestination(page);
    childBookmark.Destination.Location = new PointF(200, 300);
    childBookmark.Destination.Zoom = 2F;

    //Sets the text style and color.
    bookmark.TextStyle = PdfTextStyle.Bold;
    bookmark.Color = Syncfusion.Drawing.Color.Red;

    //Set the font.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

    //Draw text in the PDF page.
    page.Graphics.DrawString("Parent Bookmark", font, PdfBrushes.Red, new PointF(20, 20));
    page.Graphics.DrawString("Child Bookmark", font, PdfBrushes.DarkSeaGreen, new PointF(200, 300));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}