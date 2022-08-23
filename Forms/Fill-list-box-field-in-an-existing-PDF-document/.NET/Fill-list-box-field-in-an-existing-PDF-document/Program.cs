// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Set the default appearance of the PDF form.
loadedDocument.Form.SetDefaultAppearance(true);

//Get the loaded form.
PdfLoadedForm loadedForm = loadedDocument.Form;

//Fill list box.
PdfLoadedListBoxField loadedListBox = loadedForm.Fields[5] as PdfLoadedListBoxField;

//Fill list box and Modify the list box select index.
loadedListBox.SelectedIndex = new int[1] { 2 };

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
