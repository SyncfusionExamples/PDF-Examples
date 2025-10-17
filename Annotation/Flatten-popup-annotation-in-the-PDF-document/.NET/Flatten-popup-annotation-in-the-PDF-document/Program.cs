using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get all the pages.
    foreach (PdfLoadedPage loadedPage in loadedDocument.Pages)
    {
        foreach (PdfLoadedAnnotation annotation in loadedPage.Annotations)
        {
            if (annotation is PdfLoadedPopupAnnotation)
            {
                //Enable the flatten annotation.
                annotation.Flatten = true;

                //Enable flatten for the pop-up window annotation.
                annotation.FlattenPopUps = true;
            }
        }
    }

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}