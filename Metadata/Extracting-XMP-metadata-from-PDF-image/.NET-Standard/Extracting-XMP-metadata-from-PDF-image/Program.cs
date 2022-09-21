// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Xmp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Exporting;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the first page.
PdfPageBase pageBase = loadedDocument.Pages[0];

//Extracts all the images info from first page.
PdfImageInfo[] imagesInfo = pageBase.GetImagesInfo();

//Extracts the XMP metadata from PDF image.
XmpMetadata metadata = imagesInfo[0].Metadata;

//Close the document.
loadedDocument.Close(true);