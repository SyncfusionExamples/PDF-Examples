// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Create a new PDF XFA document.
PdfXfaDocument document = new PdfXfaDocument();

//Add new XFA page.
PdfXfaPage xfaPage = document.Pages.Add();

//Create a new PDF XFA form with horizontal flow direction.
PdfXfaForm mainForm = new PdfXfaForm(xfaPage, PdfXfaFlowDirection.Horizontal, xfaPage.GetClientSize().Width);

//Create a numeric field and add the properties.
PdfXfaNumericField numericField = new PdfXfaNumericField("numericField", new SizeF(200, 20));

//Set the caption text.
numericField.Caption.Text = "Numeric Field";

//Set the pattern string.
numericField.PatternString = "zzzzzzzzz9";

//Add the field to the XFA form.
mainForm.Fields.Add(numericField);

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