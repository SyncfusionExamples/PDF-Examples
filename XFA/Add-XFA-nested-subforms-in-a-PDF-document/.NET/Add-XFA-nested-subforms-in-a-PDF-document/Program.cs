// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Xfa;

//Create a new PDF XFA document.
PdfXfaDocument document = new PdfXfaDocument();

//Add new XFA page.
PdfXfaPage xfaPage = document.Pages.Add();

//Create a font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);

//Create a new PDF XFA form with horizontal flow direction.
PdfXfaForm mainForm = new PdfXfaForm(PdfXfaFlowDirection.Horizontal, xfaPage.GetClientSize().Width);

//Create a text element.
PdfXfaTextElement element = new PdfXfaTextElement("Main Form", font, 400, 20);

//Add the field to the XFA form.
mainForm.Fields.Add(element);

//Create a form.
PdfXfaForm form1 = new PdfXfaForm(PdfXfaFlowDirection.Vertical, 400);

//Create a text element. 
PdfXfaTextElement element1 = new PdfXfaTextElement("First Form", font, 400, 20);

//Add the form field to the XFA form. 
form1.Fields.Add(element1);

//Create a another XFA form with horizontal flow direction. 
PdfXfaForm form2 = new PdfXfaForm(PdfXfaFlowDirection.Horizontal, 400);

//Create a text element. 
PdfXfaTextElement element2 = new PdfXfaTextElement("Second Form", font, 400, 20);

//Add the form fields to the XFA form. 
form2.Fields.Add(element2);
form1.Fields.Add(form2);

//Add the field of form from one to another. 
mainForm.Fields.Add(form1);

//Add the XFA form to the document
document.XfaForm = mainForm;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream, PdfXfaType.Dynamic);
}

//Close the document.
document.Close();