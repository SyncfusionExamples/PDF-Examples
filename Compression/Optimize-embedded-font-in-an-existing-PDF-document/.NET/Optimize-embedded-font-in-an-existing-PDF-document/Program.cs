using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Create a new compression option.
    PdfCompressionOptions options = new PdfCompressionOptions();

    //Enable the optimize font option
    options.OptimizeFont = true;

    //Assign the compression option to the document
    loadedDocument.Compress(options);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
