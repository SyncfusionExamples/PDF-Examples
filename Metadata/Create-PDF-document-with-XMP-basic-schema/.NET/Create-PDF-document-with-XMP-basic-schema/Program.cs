using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create a page.
    PdfPage page = document.Pages.Add();

    //Get metaData object.
    XmpMetadata metaData = document.DocumentInformation.XmpMetadata;

    //XMP Basic Schema.
    BasicSchema basic = metaData.BasicSchema;

    //Set the basic details of the document.
    basic.Advisory.Add("advisory");
    basic.BaseURL = new Uri("http://google.com");
    basic.CreateDate = DateTime.Now;
    basic.CreatorTool = "creator tool";
    basic.Identifier.Add("identifier");
    basic.Label = "label";
    basic.MetadataDate = DateTime.Now;
    basic.ModifyDate = DateTime.Now;
    basic.Nickname = "nickname";
    basic.Rating.Add(-25);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
