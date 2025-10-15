using Syncfusion.Pdf.Parsing;
using System.Reflection.Metadata;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the existing PDF form.
    PdfLoadedForm lForm = loadedDocument.Form as PdfLoadedForm;

    //Set the complex script layout.
    lForm.ComplexScript = true;

    //Set flatten.
    lForm.Flatten = true;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}


