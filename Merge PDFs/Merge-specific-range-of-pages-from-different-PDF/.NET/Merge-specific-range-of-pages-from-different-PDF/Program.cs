using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Create a new PDF document 
using (PdfDocument finalDocument = new PdfDocument())
{
    //Open the first PDF file
    using (FileStream firstStream = new FileStream(Path.GetFullPath(@"Data/File1.pdf"), FileMode.Open, FileAccess.Read))
    {
        //Load the first PDF document 
        PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(firstStream);
        //Import a range of pages from the first PDF document into the final document 
        //The range starts at page 2 and ends at the last page 
        finalDocument.ImportPageRange(loadedDocument1, 1, loadedDocument1.Pages.Count - 1);
        //Open the second PDF file 
        using (FileStream secondStream = new FileStream(Path.GetFullPath(@"Data/File2.pdf"), FileMode.Open, FileAccess.Read))
        {
            //Load the second PDF document 
            PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(secondStream);
            //Import a range of pages from the second PDF document into the final document.
            //The range starts at page 2 and ends at page 5 
            finalDocument.ImportPageRange(loadedDocument2, 2, 5);
            //Save the final document into a memory stream 
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                finalDocument.Save(outputFileStream);
            }
        }
    }
}