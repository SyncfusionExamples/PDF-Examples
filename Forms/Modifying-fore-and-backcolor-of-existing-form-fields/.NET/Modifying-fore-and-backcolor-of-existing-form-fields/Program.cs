// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
