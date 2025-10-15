using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the loaded form.
    PdfLoadedForm form = loadedDocument.Form;

    //Get the form field collection. 
    PdfLoadedFormFieldCollection fields = form.Fields;

    //Enumerates the form fields.
    for (int i = 0; i < fields.Count; i++)
    {
        if (fields[i] is PdfLoadedTextBoxField)
        {
            //Get the loaded textbox field and fill it.
            PdfLoadedTextBoxField loadedTextBoxField = fields[i] as PdfLoadedTextBoxField;
            loadedTextBoxField.Text = "Text";
        }
    }

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}