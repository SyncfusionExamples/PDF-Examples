using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the first PDF document.
using (PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(Path.GetFullPath(@"Data/File1.pdf")))
//Load the PDF document.
using (PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(Path.GetFullPath(@"Data/File1.pdf")))
{
    //Creates the new document.
    PdfDocument document = new PdfDocument();

    //Imports and arranges the pages.
    document.ImportPage(loadedDocument1, 1);
    document.ImportPage(loadedDocument2, 0);

    //Save the PDF document to file stream.
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));

    //Close the document.
    document.Close(true);
}