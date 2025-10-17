using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;
using System.Reflection.Metadata;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the loaded form.
    PdfLoadedForm loadedForm = loadedDocument.Form;

    //Get the loaded form field and modify the properties.
    PdfLoadedTextBoxField loadedTextBoxField = loadedForm.Fields[0] as PdfLoadedTextBoxField;
    RectangleF newBounds = new RectangleF(100, 100, 150, 50);
    loadedTextBoxField.Bounds = newBounds;
    loadedTextBoxField.SpellCheck = true;
    loadedTextBoxField.Text = "New text of the field.";
    loadedTextBoxField.Password = false;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}