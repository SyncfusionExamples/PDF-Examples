using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
for (int pageIndex = 0;pageIndex<loadedDocument.PageCount; pageIndex++)
{
    //Gets the page
    PdfPageBase loadedPage = loadedDocument.Pages[pageIndex] as PdfPageBase;
    //Set the rotation for loaded page.
    loadedPage.Rotation = PdfPageRotateAngle.RotateAngle90;
    using (PdfDocument outputDocument = new PdfDocument())
    {
        //Import the pages to the new PDF document.  
        outputDocument.ImportPage(loadedDocument, pageIndex);
        //Save the document
        outputDocument.Save(Path.GetFullPath(@"Output/Output" + pageIndex+".pdf"));
    }
}

