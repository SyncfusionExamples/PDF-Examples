using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

// Create a PDF document.
using (PdfDocument finalDocument = new PdfDocument())
{
    //Load the first PDF document. 
    using (FileStream firstStream = new FileStream(Path.GetFullPath(@"Data/File1.pdf"), FileMode.Open, FileAccess.Read))
    //Load the second PDF document. 
    using (FileStream secondStream = new FileStream(Path.GetFullPath(@"Data/File2.pdf"), FileMode.Open, FileAccess.Read))
    {
        //Create a list of streams to merge.   
        Stream[] streams = { firstStream, secondStream };
        //Merge the PDF documents.  
        PdfDocumentBase.Merge(finalDocument, streams);
        //Create a bookmark for the first PDF file. 
        PdfBookmark bookmark1 = finalDocument.Bookmarks.Add("Chapter 1 - Barcodes");
        //Sets the destination page for first bookmark.  
        bookmark1.Destination = new PdfDestination(finalDocument.Pages[0]);
        //Sets the destination location for first bookmark.  
        bookmark1.Destination.Location = new PointF(20, 20);
        //Create a bookmark for the second PDF file. 
        PdfBookmark bookmark2 = finalDocument.Bookmarks.Add("Chapter 2 - HTTP Succinctly");
        //Sets the destination page for second bookmark.  
        bookmark2.Destination = new PdfDestination(finalDocument.Pages[3]);
        //Sets the destination location for second bookmark.  
        bookmark2.Destination.Location = new PointF(20, 20);
        
        //Save the PDF document
        finalDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

    }
}
