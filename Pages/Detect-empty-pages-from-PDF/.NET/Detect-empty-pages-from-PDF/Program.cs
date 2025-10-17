using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets the page.
    PdfPageBase loadedPage = loadedDocument.Pages[0] as PdfPageBase;

    //Get the page is blank or not.
    bool isEmpty = loadedPage.IsBlank;

    //Check whether page is blank or not. 
    if (isEmpty)
    {
        Console.WriteLine("The page is blank");
    }
    else
    {
        Console.WriteLine("The page is not blank");
    }
}

