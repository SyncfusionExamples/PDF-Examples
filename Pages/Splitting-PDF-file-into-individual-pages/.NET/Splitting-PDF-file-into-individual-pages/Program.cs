using Syncfusion.Pdf.Parsing;

//Load the PDF document
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Split the pages into separate documents
    loadedDocument.Split("Output" + "{0}.pdf");
}