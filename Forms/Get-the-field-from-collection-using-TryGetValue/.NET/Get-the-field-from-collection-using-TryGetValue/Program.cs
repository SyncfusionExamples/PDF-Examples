using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the form from the loaded document.
    PdfLoadedForm form = loadedDocument.Form;

    //Load the form field collections from the form.
    PdfLoadedFormFieldCollection fieldCollection = form.Fields as PdfLoadedFormFieldCollection;
    string fieldValue = string.Empty;

    //Get the field value using TryGetValue Method.
    fieldCollection.TryGetValue("Name", out fieldValue);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}