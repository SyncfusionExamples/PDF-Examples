using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the loaded form.
    PdfLoadedForm loadedForm = loadedDocument.Form;

    //Get the loaded form field.
    PdfLoadedTextBoxField loadedTextBoxField = loadedForm.Fields[0] as PdfLoadedTextBoxField;

    //Get fore color of the field.
    PdfColor foreColor = loadedTextBoxField.ForeColor;

    //Set the fore color.
    loadedTextBoxField.ForeColor = new PdfColor(Color.Red);

    //Get background color of the field.
    PdfColor backColor = loadedTextBoxField.BackColor;

    //Set the background color.
    loadedTextBoxField.BackColor = new PdfColor(Color.Green);

    //Set the text. 
    loadedTextBoxField.Text = "Johnson";

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
