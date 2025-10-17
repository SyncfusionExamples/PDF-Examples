using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get all the pages
    foreach (PdfLoadedPage loadedPage in loadedDocument.Pages)
    {
        //Flatten all the annotations in the page
        loadedPage.Annotations.Flatten = true;
    }

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}