// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Create a new PDF XFA document.
PdfXfaDocument document = new PdfXfaDocument();

//Add a new XFA page.
PdfXfaPage xfaPage = document.Pages.Add();

//Create a new PDF XFA form.
PdfXfaForm mainForm = new PdfXfaForm("subform1", xfaPage, xfaPage.GetClientSize().Width);

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

//Add the field to the XFA form.
mainForm.Fields.Add(listBoxField);

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
