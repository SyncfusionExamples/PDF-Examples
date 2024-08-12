using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;


//Load the PDF document.
FileStream docStream = new FileStream(@"Data/Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
for (int pageIndex = 0;pageIndex<loadedDocument.PageCount; pageIndex++)
{
    //Gets the page
    PdfPageBase loadedPage = loadedDocument.Pages[pageIndex] as PdfPageBase;
    //Set the rotation for loaded page.
    loadedPage.Rotation = PdfPageRotateAngle.RotateAngle90;
    using (var outputDocument = new PdfDocument())
    {
        //Import the pages to the new PDF document.  
        outputDocument.ImportPage(loadedDocument, pageIndex);
        //Save the document into a filestream object. 
        using (FileStream outputFileStream = new FileStream("Output/Output" + pageIndex+".pdf", FileMode.Create, FileAccess.Write))
        {
            outputDocument.Save(outputFileStream);
        }
    }
}

