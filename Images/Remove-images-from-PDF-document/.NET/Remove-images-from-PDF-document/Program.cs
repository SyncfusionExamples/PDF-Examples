using Syncfusion.Pdf;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the first page.
    PdfPageBase pageBase = loadedDocument.Pages[0];

    //Extract images from the first page.
    PdfImageInfo[] imageInfo = loadedDocument.Pages[0].GetImagesInfo();

    //Remove the Image.
    pageBase.RemoveImage(imageInfo[0]);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
