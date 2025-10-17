using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the loaded form.
    PdfLoadedForm loadedForm = loadedDocument.Form;

    //load the check box from field collection.
    PdfLoadedCheckBoxField loadedCheckBoxField = loadedForm.Fields[6] as PdfLoadedCheckBoxField;

    //Fill the checkbox.
    loadedCheckBoxField.Items[0].Checked = true;

    //Check the checkbox if it is not grouped.
    loadedCheckBoxField.Checked = true;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
