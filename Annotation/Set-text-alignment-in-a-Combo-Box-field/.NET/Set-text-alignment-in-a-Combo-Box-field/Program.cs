using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Load an existing combo box field by its name.
    PdfLoadedComboBoxField comboField = loadedDocument.Form.Fields["JobTitle"] as PdfLoadedComboBoxField;
    // Set text alignment to center for the combo box field.
    comboField.TextAlignment = PdfTextAlignment.Center;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}