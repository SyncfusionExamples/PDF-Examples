// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Creates new PDF document.
PdfDocument document = new PdfDocument();

//Set the document information title. 
document.DocumentInformation.Title = "Form Fields";

//Adds new page.
PdfPage page = document.Pages.Add();

// Create a text box field.
PdfTextBoxField textBoxField = new PdfTextBoxField(page, "This is form field text box");

//Adding tag to the text box field.
textBoxField.PdfTag = new PdfStructureElement(PdfTagType.Form);

//Add text to the textbox field. 
textBoxField.Text = "Filled text box";

//Set properties to the text box.
textBoxField.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
textBoxField.BorderColor = new PdfColor(Color.Gray);
textBoxField.BorderStyle = PdfBorderStyle.Beveled;
textBoxField.Bounds = new RectangleF(200, 0, 90, 20);
textBoxField.ToolTip = "TextBox field";

//Add form field to the PDF document. 
document.Form.Fields.Add(textBoxField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
