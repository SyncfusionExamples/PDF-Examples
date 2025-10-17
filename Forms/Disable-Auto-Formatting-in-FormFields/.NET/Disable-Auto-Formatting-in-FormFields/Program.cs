using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Access the form field named "email" from the PDF form
    PdfLoadedField field = loadedDocument.Form.Fields["email"] as PdfLoadedField;

    // Disable automatic formatting to prevent behaviors like JavaScript execution
    loadedDocument.Form.DisableAutoFormat = true;

    // Check if the field is a text box and assign a plain string value
    if (field is PdfLoadedTextBoxField textBoxField)
    {
        // Set the text box value to a raw email string without formatting
        textBoxField.Text = "12345@gmail.com";
    }

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}