// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Get the radio button group.
PdfLoadedXfaRadioButtonGroup loadedRadioButtonGroup = (loadedForm.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["radioGroup[0]"] as PdfLoadedXfaRadioButtonGroup;

//Get the radio button field.
PdfLoadedXfaRadioButtonField loadedRadioButtonField = loadedRadioButtonGroup.Fields[0] as PdfLoadedXfaRadioButtonField;

//Check the radio button.
loadedRadioButtonField.IsChecked = true;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();

