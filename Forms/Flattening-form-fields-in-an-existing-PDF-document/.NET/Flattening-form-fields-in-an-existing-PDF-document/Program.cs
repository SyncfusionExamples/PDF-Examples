using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the loaded form.
    PdfLoadedForm loadedForm = loadedDocument.Form;

    //Get the field collection.
    PdfLoadedFormFieldCollection fields = loadedForm.Fields;

    //Get the loaded text box field.
    PdfLoadedTextBoxField loadedTextBoxField = fields[0] as PdfLoadedTextBoxField;

    //Fill the textbox field. 
    loadedTextBoxField.Text = "Syncfusion";

    //Flatten the whole form.
    loadedForm.Flatten = true;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

