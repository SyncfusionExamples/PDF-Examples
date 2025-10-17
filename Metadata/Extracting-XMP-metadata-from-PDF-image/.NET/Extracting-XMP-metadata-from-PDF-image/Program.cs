using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Xmp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Exporting;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the first page.
    PdfPageBase pageBase = loadedDocument.Pages[0];

    //Extracts all the images info from first page.
    PdfImageInfo[] imagesInfo = pageBase.GetImagesInfo();

    //Extracts the XMP metadata from PDF image.
    XmpMetadata metadata = imagesInfo[0].Metadata;

    Console.WriteLine(metadata.XmlData);
}