using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the page count.
    int pageCount = loadedDocument.Pages.Count;

    //Write the number of pages in a PDF document in console window. 
    Console.WriteLine("Number of pages in the PDF document is " + pageCount);
}