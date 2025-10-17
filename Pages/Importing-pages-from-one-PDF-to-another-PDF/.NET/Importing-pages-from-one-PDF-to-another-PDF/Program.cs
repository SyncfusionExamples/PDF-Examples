using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Create a new PDF document.
    PdfDocument document = new PdfDocument();

    //Set the page starting and end index. 
    int startIndex = 0;
    int endIndex = loadedDocument.Pages.Count - 1;

    //Import all the pages to the new PDF document.
    document.ImportPageRange(loadedDocument, startIndex, endIndex);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}