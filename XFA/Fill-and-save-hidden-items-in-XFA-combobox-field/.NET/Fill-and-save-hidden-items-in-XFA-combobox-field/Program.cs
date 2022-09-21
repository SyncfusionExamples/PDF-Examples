// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Get the loaded combo box field.
PdfLoadedXfaComboBoxField loadedComboBoxField = (loadedForm.Fields["Page1[0]"] as PdfLoadedXfaForm).Fields["WorkTypeList[0]"] as PdfLoadedXfaComboBoxField;

//Set the combo box selected index using hidden items.
loadedComboBoxField.SelectedValue = loadedComboBoxField.HiddenItems[1];

//Save the combo box field hidden values.
List<string> hiddenValues = new List<string>();
hiddenValues = loadedComboBoxField.HiddenItems;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();
