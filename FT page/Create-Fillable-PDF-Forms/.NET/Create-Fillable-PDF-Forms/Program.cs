using Syncfusion.Pdf.Parsing;

// Load the existing PDF document.
using (FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream))
{
    // Create the form if it doesn't exist.
    if (loadedDocument.Form == null)
        loadedDocument.CreateForm();

    // Fill in the name text box.
    PdfLoadedTextBoxField name = loadedDocument.Form.Fields[1] as PdfLoadedTextBoxField;
    name.Text = "John Milton";

    // Fill in the email text box.
    PdfLoadedTextBoxField email = loadedDocument.Form.Fields[2] as PdfLoadedTextBoxField;
    email.Text = "john.milton@example.com";

    // Select a gender radio button (0 = first option).
    PdfLoadedRadioButtonListField gender = loadedDocument.Form.Fields[3] as PdfLoadedRadioButtonListField;
    gender.SelectedIndex = 0;

    // Fill in the date of birth field.
    PdfLoadedTextBoxField dob = loadedDocument.Form.Fields[0] as PdfLoadedTextBoxField;
    dob.Text = "May 12, 2000";

    // Select a country from the combo box.
    PdfLoadedComboBoxField country = loadedDocument.Form.Fields[4] as PdfLoadedComboBoxField;
    country.SelectedValue = "Alabama";

    // Check the newsletter subscription box.
    PdfLoadedCheckBoxField newsletter = loadedDocument.Form.Fields[5] as PdfLoadedCheckBoxField;
    newsletter.Checked = true;

    // Ensure proper rendering in PDF viewers.
    loadedDocument.Form.SetDefaultAppearance(false);

    // Save the updated PDF to a new file.
    using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        loadedDocument.Save(outputStream);
    }

    // Close the PDF document.
    loadedDocument.Close(true);
}