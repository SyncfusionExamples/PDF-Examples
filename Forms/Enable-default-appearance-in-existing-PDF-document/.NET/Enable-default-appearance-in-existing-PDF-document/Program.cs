using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the loaded form.
    PdfLoadedForm loadedForm = loadedDocument.Form;

    //Get the loaded text box field and fill it.
    PdfLoadedTextBoxField loadedTextBoxField = loadedForm.Fields[0] as PdfLoadedTextBoxField;
    loadedTextBoxField.Text = "First Name";

    //Enable the default Appearance.
    loadedDocument.Form.SetDefaultAppearance(false);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}


