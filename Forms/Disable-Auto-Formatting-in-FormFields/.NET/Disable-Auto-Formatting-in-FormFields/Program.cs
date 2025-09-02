using Syncfusion.Pdf.Parsing;

// Load the existing PDF document
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read));

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

// Save the modified PDF document to a new file using a file stream
using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    loadedDocument.Save(outputStream);
}
// Close and dispose the document to release resources
loadedDocument.Close(true);