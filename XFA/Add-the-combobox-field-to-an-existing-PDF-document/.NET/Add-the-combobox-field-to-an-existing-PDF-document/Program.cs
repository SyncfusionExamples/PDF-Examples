// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Create a combo box field and add the properties.
PdfXfaComboBoxField comboBoxField = new PdfXfaComboBoxField("comboField", new SizeF(200, 20));

//Set the caption text.
comboBoxField.Caption.Text = "Job Title";

//Add the combo box items.
comboBoxField.Items.Add("Development");
comboBoxField.Items.Add("Support");
comboBoxField.Items.Add("Documentation");

//Add the field to the existing XFA form.
loadedForm.Fields.Add(comboBoxField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();

