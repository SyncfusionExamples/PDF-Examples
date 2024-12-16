using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

// Load an existing document from a file stream.
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.Read))
{
    PdfLoadedDocument doc = new PdfLoadedDocument(fileStream);
    // Load an existing combo box field by its name.
    PdfLoadedComboBoxField comboField = doc.Form.Fields["JobTitle"] as PdfLoadedComboBoxField;
    // Set text alignment to center for the combo box field.
    comboField.TextAlignment = PdfTextAlignment.Center;

    // Save the updated document to a file stream.
    using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output\Output.pdf"), FileMode.Create, FileAccess.Write))
    {
        doc.Save(outputStream);
    }
    // Close the document.
    doc.Close(true);
}