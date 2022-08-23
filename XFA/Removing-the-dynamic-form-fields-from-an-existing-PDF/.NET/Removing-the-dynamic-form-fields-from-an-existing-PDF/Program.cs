// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Get the existing XFA form. 
PdfLoadedXfaForm form = loadedForm.Fields["subform1[0]"] as PdfLoadedXfaForm;

//Get the existing field.
PdfLoadedXfaTextBoxField loadedText = (form.Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["FirstName[0]"] as PdfLoadedXfaTextBoxField;

//Remove the field.
loadedForm.Fields.Remove(loadedText);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();
