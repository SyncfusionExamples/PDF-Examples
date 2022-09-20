// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create a PDF document.
PdfDocument pdfDoc = new PdfDocument();

//Create a page.
PdfPage page = pdfDoc.Pages.Add();

//Get metaData object.
XmpMetadata metaData = pdfDoc.DocumentInformation.XmpMetadata;

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
    pdfDoc.Save(outputFileStream);
}

//Close the document.
pdfDoc.Close(true);
