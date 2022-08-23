// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
