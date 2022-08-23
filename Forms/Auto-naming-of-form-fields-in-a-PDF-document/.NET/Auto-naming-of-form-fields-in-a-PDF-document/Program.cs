// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page to the PDF document.
PdfPage page = document.Pages.Add();

//Create the form.
PdfForm form = document.Form;

//Enable the field auto naming.
form.FieldAutoNaming = true;

//Create a text box field and add the properties.
PdfTextBoxField textBoxField = new PdfTextBoxField(page, "Name");
textBoxField.Bounds = new RectangleF(0, 0, 100, 20);
textBoxField.ToolTip = "FirstName";
textBoxField.Text = "John";

//Add the form field to the document.
document.Form.Fields.Add(textBoxField);

//Create a text box field with the same name and add the properties.
PdfTextBoxField textBoxField1 = new PdfTextBoxField(page, "Name");
textBoxField1.Bounds = new RectangleF(0, 50, 100, 20);
textBoxField1.ToolTip = "LastName";
textBoxField1.Text = "Doe";

//Add form field to the document.
document.Form.Fields.Add(textBoxField1);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);