// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Get the loaded date time field.
PdfLoadedXfaDateTimeField loadedDateTimeField = (loadedForm.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["date[0]"] as PdfLoadedXfaDateTimeField;

//Set the value.
loadedDateTimeField.Value = DateTime.Now;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();
