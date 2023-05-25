
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document.
FileStream docStream = new FileStream("../../../Data/Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
//Rearrange the page by index
loadedDocument.Pages.ReArrange(new int[] { 1,0,3,2 });
// The document will contain minimum 4 pages of the input PDF document.  
using (var outputDocument = new PdfDocument())
{
    //Import the pages to the new PDF document.  
    outputDocument.ImportPageRange(loadedDocument, 0, 3);
    //Save the document into a filestream object. 
    using (FileStream outputFileStream = new FileStream("../../../Output.pdf", FileMode.Create, FileAccess.Write))
    {
        outputDocument.Save(outputFileStream);
    }
}

