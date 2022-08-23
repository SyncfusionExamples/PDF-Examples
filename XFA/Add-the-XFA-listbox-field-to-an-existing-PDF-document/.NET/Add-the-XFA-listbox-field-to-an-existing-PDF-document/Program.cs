// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Load the PDF document
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Create a list box field and add the properties.
PdfXfaListBoxField listBoxField = new PdfXfaListBoxField("listBoxField", new SizeF(150, 50));

//Set the caption text.
listBoxField.Caption.Text = "Known Languages";
listBoxField.Caption.Position = PdfXfaPosition.Top;
listBoxField.Caption.HorizontalAlignment = PdfXfaHorizontalAlignment.Center;

//Add the list box items.
listBoxField.Items.Add("English");
listBoxField.Items.Add("French");
listBoxField.Items.Add("German");

//Add the field to the existing XFA form.
loadedForm.Fields.Add(listBoxField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();

