using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get all the pages
    foreach (PdfLoadedPage loadedPage in loadedDocument.Pages)
    {
        //Flatten all the annotations in the page
        foreach (PdfLoadedAnnotation annotation in loadedPage.Annotations)
        {
            //Check for the circle annotation
            if (annotation is PdfLoadedCircleAnnotation)
            {
                //Flatten the circle annotation
                annotation.Flatten = true;
            }
        }
    }

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
