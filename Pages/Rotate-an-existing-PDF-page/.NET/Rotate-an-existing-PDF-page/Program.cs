using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets the page.
    PdfPageBase loadedPage = loadedDocument.Pages[0] as PdfPageBase;

    //Set the rotation for loaded page.
    loadedPage.Rotation = PdfPageRotateAngle.RotateAngle90;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
