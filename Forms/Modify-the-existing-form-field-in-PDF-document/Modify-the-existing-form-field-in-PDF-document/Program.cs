// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;
using System.Reflection.Metadata;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the loaded form.
PdfLoadedForm loadedForm = loadedDocument.Form;

//Get the loaded form field and modify the properties.
PdfLoadedTextBoxField loadedTextBoxField = loadedForm.Fields[0] as PdfLoadedTextBoxField;
RectangleF newBounds = new RectangleF(100, 100, 150, 50);
loadedTextBoxField.Bounds = newBounds;
loadedTextBoxField.SpellCheck = true;
loadedTextBoxField.Text = "New text of the field.";
loadedTextBoxField.Password = false;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);