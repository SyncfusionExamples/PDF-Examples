// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Xfa;

//Create a new PDF XFA document.
PdfXfaDocument document = new PdfXfaDocument();

//Add a new XFA page.
PdfXfaPage xfaPage = document.Pages.Add();

//Create a new PDF XFA form.
PdfXfaForm mainForm = new PdfXfaForm("subform1", xfaPage, xfaPage.GetClientSize().Width);

//Create a line and add the properties.
PdfXfaLine line = new PdfXfaLine(new PointF(0, 0), new PointF(200, 0), 3);

//Set the line color.
line.Color = new PdfColor(Color.FromArgb(0, 255, 0, 0));

//Add the text line to the XFA form.
mainForm.Fields.Add(line);

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