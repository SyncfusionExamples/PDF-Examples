using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create a Page.
    PdfPage page = document.Pages.Add();

    //Gets XMP object.
    XmpMetadata metaData = document.DocumentInformation.XmpMetadata;

    //XMP Page text Schema.
    PagedTextSchema pagedText = metaData.PagedTextSchema;

    //Sets the Page text Schema details of the document.
    pagedText.MaxPageSize.Width = 500;
    pagedText.MaxPageSize.Height = 750;
    pagedText.NPages = 1;
    pagedText.PlateNames.Add("Sample page");

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
