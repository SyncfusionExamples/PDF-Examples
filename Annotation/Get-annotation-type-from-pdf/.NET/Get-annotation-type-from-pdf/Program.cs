using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the pages of the PDF file
    for (int i = 0; i < loadedDocument.PageCount; i++)
    {
        Console.WriteLine("Page Number: " + i);
        PdfLoadedPage page = loadedDocument.Pages[i] as PdfLoadedPage;

        //Get the annotation type.
        foreach (PdfLoadedAnnotation annotation in page.Annotations)
        {
            Console.WriteLine("Annotation Type: " + annotation.Type.ToString());
        }
    }
}