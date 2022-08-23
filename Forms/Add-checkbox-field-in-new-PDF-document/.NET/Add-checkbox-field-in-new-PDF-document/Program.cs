// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page to PDF document.
PdfPage page = document.Pages.Add();

//Create Check Box field.
PdfCheckBoxField checkBoxField = new PdfCheckBoxField(page, "CheckBox");

//Set check box properties.
checkBoxField.ToolTip = "Check Box";
checkBoxField.Bounds = new Syncfusion.Drawing.RectangleF(0, 20, 10, 10);

//Add the form field to the document.
document.Form.Fields.Add(checkBoxField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);