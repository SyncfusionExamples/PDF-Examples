// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Get the stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Create a button field and add the properties.
PdfXfaButtonField buttonField = new PdfXfaButtonField("buttonField", new SizeF(100, 20));

//Set the caption text.
buttonField.Content = "Click";

//Add the field to the existing XFA form.
loadedForm.Fields.Add(buttonField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();