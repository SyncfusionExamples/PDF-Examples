using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

// Initialize the HTML to PDF converter
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
// Enable form conversion
BlinkConverterSettings settings = new BlinkConverterSettings
{
    EnableForm = true
};
htmlConverter.ConverterSettings = settings;
// Convert the HTML file to a PDF document
using (PdfDocument document = htmlConverter.Convert(Path.GetFullPath(@"Data/Input.html")))
{
    // Set default appearance for form fields
    document.Form.SetDefaultAppearance(false);

    // Save the PDF document to a memory stream
    using (MemoryStream stream = new MemoryStream())
    {
        // Load the saved PDF document
        document.Save(stream);
        // Load the PDF document containing form fields
        PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);
        // Fill the form fields
        PdfLoadedForm form = loadedDocument.Form;
        // Fill the "name" field
        if (form.Fields["name"] is PdfLoadedTextBoxField nameField)
        {
            nameField.Text = "XYZ";
        }
        // Fill the "email" field
        if (form.Fields["email"] is PdfLoadedTextBoxField emailField)
        {
            emailField.Text = "xyz@example.com";
        }
        // Select "Male" in the "gender" dropdown
        if (form.Fields["gender"] is PdfLoadedComboBoxField genderField)
        {
            genderField.SelectedValue = "Male";
        }
        // Fill the "signature" field
        if (form.Fields["signature"] is PdfLoadedTextBoxField signatureTextBox)
        {
            // Get the original field's position and page
            RectangleF bounds = signatureTextBox.Bounds;
            PdfPageBase page = signatureTextBox.Page;
            // Remove the original textbox field
            form.Fields.Remove(signatureTextBox);
            // Create a new signature field at the same location
            PdfSignatureField signatureField = new PdfSignatureField(page, "ClientSignature")
            {
                Bounds = bounds
            };
            // Add the new signature field to the form
            form.Fields.Add(signatureField);
        }
        // Save the PDF document
        loadedDocument.Save(Path.GetFullPath(@"Output/Output2.pdf"));
    }
}