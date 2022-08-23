// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Create a new PDF XFA document.
PdfXfaDocument document = new PdfXfaDocument();

//Add a new XFA page.
PdfXfaPage xfaPage = document.Pages.Add();

//Create a new PDF XFA form.
PdfXfaForm mainForm = new PdfXfaForm("subform1", xfaPage, xfaPage.GetClientSize().Width);

//Create a radio button group.
PdfXfaRadioButtonGroup group = new PdfXfaRadioButtonGroup("radioGroup");
group.FlowDirection = PdfXfaFlowDirection.Vertical;

//Create a radio button field and add the properties.
PdfXfaRadioButtonField radioButtonField1 = new PdfXfaRadioButtonField("r1", new SizeF(80, 20));
//Set the caption text.
radioButtonField1.Caption.Text = "Male";

//Create a radio button field and add the properties. 
PdfXfaRadioButtonField radioButtonField2 = new PdfXfaRadioButtonField("r2", new SizeF(80, 20));
radioButtonField2.Caption.Text = "Female";

//Add the radio button fields to the radio button group.
group.Items.Add(radioButtonField1);
group.Items.Add(radioButtonField2);

//Add the field to the XFA form.
mainForm.Fields.Add(group);

//Add the XFA form to the document.
document.XfaForm = mainForm;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream, PdfXfaType.Dynamic);
}

//Close the document.
document.Close();

