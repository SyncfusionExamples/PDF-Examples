using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Disable the incremental update.
    loadedDocument.FileStructure.IncrementalUpdate = false;

    //Set the compression level.
    loadedDocument.Compression = PdfCompressionLevel.Best;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
