using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;

// Open the input PDF file stream.
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the PDF document from the input stream.
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream);

    // Access the existing form fields in the PDF.
    PdfLoadedForm form = loadedDocument.Form;

    // Iterate through all form fields to find checkboxes and radio button lists.
    foreach (PdfLoadedField field in form.Fields)
    {
        // If the field is a checkbox, change its checkmark color using ForeColor.
        if (field is PdfLoadedCheckBoxField checkBoxField)
        {
            checkBoxField.ForeColor = Color.Red; // Set desired checkbox color.
        }
        // If the field is a radio button list, change each item's dot color.
        else if (field is PdfLoadedRadioButtonListField radioButtonField)
        {
            foreach (PdfLoadedRadioButtonItem item in radioButtonField.Items)
            {
                item.ForeColor = Color.Blue; // Set desired radio button color.
            }
        }
    }

    // Create the output file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        // Save the modified PDF document to the new file stream.
        loadedDocument.Save(outputFileStream);
    }

    // Close the PDF document.
    loadedDocument.Close(true);
}