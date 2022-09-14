// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Create an instance for named destination.
PdfNamedDestination destination = new PdfNamedDestination("TOC");

//Set the page destination. 
destination.Destination = new PdfDestination(page);

//Set the location
destination.Destination.Location = new PointF(0, 500);

//Set zoom factor to 400 percentage
destination.Destination.Zoom = 4;

//Add the named destination to the collection
document.NamedDestinationCollection.Add(destination);

//Create a bookmark
PdfBookmark bookmark = document.Bookmarks.Add("TOC");

//Assign the named destination to the bookmark
bookmark.NamedDestination = destination;

//Set the font. 
PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

//Draw string.
page.Graphics.DrawString("Hello World!!!", font, PdfBrushes.Red, new PointF(0,500));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);