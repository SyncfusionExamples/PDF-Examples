using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the loaded form.
    PdfLoadedForm loadedForm = loadedDocument.Form;

    //Get the loaded combo box field  and modify the properties.
    PdfLoadedComboBoxField loadedComboboxField = loadedForm.Fields[4] as PdfLoadedComboBoxField;
    loadedComboboxField.SelectedIndex = 1;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
