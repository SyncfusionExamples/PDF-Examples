using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
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
    // Disable the default appearance to allow custom rendering of form fields.
    form.SetDefaultAppearance(false);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}