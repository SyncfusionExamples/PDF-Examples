// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Create a new PDF XFA document.
PdfXfaDocument document = new PdfXfaDocument();

//Add a new XFA page.
PdfXfaPage xfaPage = document.Pages.Add();

//Create a new PDF XFA form.
PdfXfaForm mainForm = new PdfXfaForm("subform1", xfaPage, xfaPage.GetClientSize().Width);

//Create a rectangle field and add the properties.
PdfXfaRectangleField rectangle = new PdfXfaRectangleField("rect1", new SizeF(100, 50));

//Set the fill color.
rectangle.Border.FillColor = new PdfXfaSolidBrush(Color.FromArgb(0, 255, 0, 0));

//Add the rectangle field to the XFA form.
mainForm.Fields.Add(rectangle);

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