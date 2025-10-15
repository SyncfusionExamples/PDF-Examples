using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Gets XMP object.
    XmpMetadata metaData = document.DocumentInformation.XmpMetadata;

    //XMP PDF Schema.
    PDFSchema pdfSchema = metaData.PDFSchema;

    //Set the PDF Schema details of the document.
    pdfSchema.Producer = "Syncfusion";
    pdfSchema.PDFVersion = "1.5";
    pdfSchema.Keywords = "Essential PDF";

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}