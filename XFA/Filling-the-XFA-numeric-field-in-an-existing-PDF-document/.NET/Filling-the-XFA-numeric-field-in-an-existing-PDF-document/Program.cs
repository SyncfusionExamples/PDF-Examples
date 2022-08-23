// See https://aka.ms/new-console-template for more information

//Get stream from an existing PDF document. 
using Syncfusion.Pdf.Xfa;

FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Get the loaded numeric field.
PdfLoadedXfaNumericField loadedNumericField = (loadedForm.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["numericField[0]"] as PdfLoadedXfaNumericField;

//fill the numeric field.
loadedNumericField.NumericValue = 945322;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();
