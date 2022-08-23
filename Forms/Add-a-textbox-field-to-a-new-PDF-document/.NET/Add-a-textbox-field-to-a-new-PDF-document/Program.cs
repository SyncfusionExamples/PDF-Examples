// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page to the PDF document.
PdfPage page = document.Pages.Add();

//Create a textbox field and add the properties.
PdfTextBoxField textBoxField = new PdfTextBoxField(page, "FirstName");
textBoxField.Bounds = new Syncfusion.Drawing.RectangleF(0, 0, 100, 20);
textBoxField.ToolTip = "First Name";

//Add the form field to the document.
document.Form.Fields.Add(textBoxField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
