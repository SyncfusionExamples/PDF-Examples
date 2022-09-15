// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

PdfLoadedXfaTextBoxField loadedText = (loadedForm.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["FirstName[0]"] as PdfLoadedXfaTextBoxField;

//Set the width and height of the field.
loadedText.Width = 200;
loadedText.Height = 30;

//Set the caption text.
loadedText.Caption.Text = "Second Name";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();

