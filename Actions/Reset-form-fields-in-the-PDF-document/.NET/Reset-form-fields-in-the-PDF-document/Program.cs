// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a PDF document.
PdfDocument document = new PdfDocument();

//Add a new page.
PdfPage page = document.Pages.Add();

//Create a Text box field.
PdfTextBoxField textBoxField = new PdfTextBoxField(page, "FirstName");

//Set properties to the textbox.
textBoxField.BorderColor = new PdfColor(Color.Gray);
textBoxField.BorderStyle = PdfBorderStyle.Beveled;
textBoxField.Bounds = new RectangleF(80, 0, 100, 20);
textBoxField.Text = "First Name";

//Add the form field to the document.
document.Form.Fields.Add(textBoxField);

//Create a Button field.
PdfButtonField clearButton = new PdfButtonField(page, "Clear");

//Set properties to the button field. 
clearButton.Bounds = new RectangleF(100, 60, 50, 20);
clearButton.ToolTip = "Clear";
document.Form.Fields.Add(clearButton);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
