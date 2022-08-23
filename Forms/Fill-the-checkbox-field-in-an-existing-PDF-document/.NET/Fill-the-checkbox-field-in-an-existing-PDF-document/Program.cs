// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the loaded form.
PdfLoadedForm loadedForm = loadedDocument.Form;

//load the check box from field collection.
PdfLoadedCheckBoxField loadedCheckBoxField = loadedForm.Fields[6] as PdfLoadedCheckBoxField;

//Fill the checkbox.
loadedCheckBoxField.Items[0].Checked = true;

//Check the checkbox if it is not grouped.
loadedCheckBoxField.Checked = true;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
