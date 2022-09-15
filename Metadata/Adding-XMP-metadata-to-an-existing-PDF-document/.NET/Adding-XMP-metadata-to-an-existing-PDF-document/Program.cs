// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Xmp;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument pdfDocument = new PdfLoadedDocument(docStream);

//Get XMP object.
XmpMetadata metaData = pdfDocument.DocumentInformation.XmpMetadata;

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);