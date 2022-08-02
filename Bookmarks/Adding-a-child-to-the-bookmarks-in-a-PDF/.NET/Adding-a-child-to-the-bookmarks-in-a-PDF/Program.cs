// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Creates a new document.
PdfDocument document = new PdfDocument();

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
page.Graphics.DrawString("Parent Bookmark", font, PdfBrushes.Red, new PointF(20,20));
page.Graphics.DrawString("Child Bookmark", font, PdfBrushes.DarkSeaGreen, new PointF(200,300));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);