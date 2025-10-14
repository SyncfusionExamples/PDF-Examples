
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
//Rearrange the page by index
loadedDocument.Pages.ReArrange(new int[] { 1,0,3,2 });
// The document will contain minimum 4 pages of the input PDF document.  
using (PdfDocument outputDocument = new PdfDocument())
{
    //Import the pages to the new PDF document.  
    outputDocument.ImportPageRange(loadedDocument, 0, 3);
    //Save the document
    outputDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
//Close the document
loadedDocument.Close(true);

