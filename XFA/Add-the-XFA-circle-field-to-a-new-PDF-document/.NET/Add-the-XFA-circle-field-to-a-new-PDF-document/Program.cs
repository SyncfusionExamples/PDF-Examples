// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Create a new PDF XFA document.
PdfXfaDocument document = new PdfXfaDocument();

//Add a new XFA page.
PdfXfaPage xfaPage = document.Pages.Add();

//Create a new PDF XFA form.
PdfXfaForm mainForm = new PdfXfaForm("subform1", xfaPage, xfaPage.GetClientSize().Width);

//Create a circle field and add the properties.
PdfXfaCircleField circle = new PdfXfaCircleField("circle", new SizeF(100, 100));

//Set the fill color.
circle.Border.FillColor = new PdfXfaSolidBrush(Color.FromArgb(0, 255, 0, 0));

//Add the text element to the XFA form.
mainForm.Fields.Add(circle);

//Add the XFA form to the document.
document.XfaForm = mainForm;

//Save the document.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    document.Save(outputFileStream, PdfXfaType.Dynamic);
}

//Close the document.
document.Close();