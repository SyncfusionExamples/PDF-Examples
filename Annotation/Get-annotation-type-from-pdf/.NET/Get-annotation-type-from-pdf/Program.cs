using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Load the PDF document using a file stream
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    using (PdfLoadedDocument document = new PdfLoadedDocument(inputStream))
    {
        //Get the pages of the PDF file
        for (int i = 0; i < document.PageCount; i++)
        {
            Console.WriteLine("Page Number: " + i);
            PdfLoadedPage page = document.Pages[i] as PdfLoadedPage;

            //Get the annotation type.
            foreach (PdfLoadedAnnotation annotation in page.Annotations)
            {
                Console.WriteLine("Annotation Type: " + annotation.Type.ToString());
            }
        }
    }
}