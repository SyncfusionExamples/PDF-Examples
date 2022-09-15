// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Xmp;

//Create a Pdf document.
PdfDocument pdfDoc = new PdfDocument();

//Create a Page.
PdfPage page = pdfDoc.Pages.Add();

//Gets XMP object.
XmpMetadata metaData = pdfDoc.DocumentInformation.XmpMetadata;

//XMP Page text Schema.
PagedTextSchema pagedText = metaData.PagedTextSchema;

//Sets the Page text Schema details of the document.
pagedText.MaxPageSize.Width = 500;
pagedText.MaxPageSize.Height = 750;
pagedText.NPages = 1;
pagedText.PlateNames.Add("Sample page");

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDoc.Save(outputFileStream);
}

//Close the document.
pdfDoc.Close(true);
