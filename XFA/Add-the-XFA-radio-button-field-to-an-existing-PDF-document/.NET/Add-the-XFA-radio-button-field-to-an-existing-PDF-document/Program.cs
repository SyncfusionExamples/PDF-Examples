// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Create a radio button group and add the properties.
PdfXfaRadioButtonGroup group = new PdfXfaRadioButtonGroup("radioGroup");
group.FlowDirection = PdfXfaFlowDirection.Vertical;

//Create a radio button field and add the properties.
PdfXfaRadioButtonField radioButtonField1 = new PdfXfaRadioButtonField("r1", new SizeF(80, 20));

//Set the caption text.
radioButtonField1.Caption.Text = "Male";

//Create the radio button field and add the properties. 
PdfXfaRadioButtonField radioButtonField2 = new PdfXfaRadioButtonField("r2", new SizeF(80, 20));

//Set the caption text. 
radioButtonField2.Caption.Text = "Female";

//Add the radio button fields to the radio button group.
group.Items.Add(radioButtonField1);
group.Items.Add(radioButtonField2);

//Add the field to the existing XFA form.
loadedForm.Fields.Add(group);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();
