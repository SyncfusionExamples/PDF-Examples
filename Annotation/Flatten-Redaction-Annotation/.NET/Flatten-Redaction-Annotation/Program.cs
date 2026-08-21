using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the annotation from annotation collection. 
    foreach (PdfAnnotation annot in loadedDocument.Pages[0].Annotations)
    {
        //Check for the Redaction annotation.
        if (annot is PdfLoadedRedactionAnnotation)
        {
            //Get the redaction annotation. 
            PdfLoadedRedactionAnnotation redactAnnot = annot as PdfLoadedRedactionAnnotation;
            //Flatten the redaction annotation. 
            redactAnnot.Flatten = true;
        }
    }
    loadedDocument.Redact();
    //Save the document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}