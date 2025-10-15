using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Create a new PDF document 
using (PdfDocument finalDocument = new PdfDocument())
{
    //Open the first PDF file
    using (PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(Path.GetFullPath(@"Data/File1.pdf")))
    {
        //Import a range of pages from the first PDF document into the final document 
        //The range starts at page 2 and ends at the last page 
        finalDocument.ImportPageRange(loadedDocument1, 1, loadedDocument1.Pages.Count - 1);
        //Open the second PDF file 
        using (PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(Path.GetFullPath(@"Data/File2.pdf")))
        {
            //Import a range of pages from the second PDF document into the final document.
            //The range starts at page 2 and ends at page 5 
            finalDocument.ImportPageRange(loadedDocument2, 2, 5);
            //Save the final document
            finalDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
        }
    }
}