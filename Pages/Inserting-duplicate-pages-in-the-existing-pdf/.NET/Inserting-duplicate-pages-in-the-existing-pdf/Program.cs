 using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets the page 
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
    //Inserts the duplicate page in the beginning of the document. 
    loadedDocument.Pages.Insert(0, loadedPage);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
