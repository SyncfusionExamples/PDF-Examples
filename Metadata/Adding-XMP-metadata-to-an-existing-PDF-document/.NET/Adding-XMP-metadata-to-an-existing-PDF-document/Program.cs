using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Xmp;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get XMP object.
    XmpMetadata metaData = loadedDocument.DocumentInformation.XmpMetadata;

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
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}