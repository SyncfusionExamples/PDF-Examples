using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

// Create a new PDF document
using (PdfDocument pdfDocument = new PdfDocument())
{
    // Add a new page to the PDF document
    PdfPage pdfPage = pdfDocument.Pages.Add();
    // Create a text box field for entering the name
    PdfTextBoxField nameField = new PdfTextBoxField(pdfPage, "DateField");
    nameField.Bounds = new RectangleF(10, 40, 200, 20);
    nameField.ToolTip = "Date";
    nameField.Text = "12/01/1995";
    //Set the scriptAction to submitButton
    nameField.Actions.KeyPressed = new PdfJavaScriptAction("AFDate_KeystrokeEx(\"m/d/yy\")");
    nameField.Actions.Format = new PdfJavaScriptAction("AFDate_FormatEx(\"m/d/yy\")");
    nameField.Actions.Validate = new PdfJavaScriptAction("AFDate_Validate(\"m/d/yy\")");
    // Add the field to the form
    pdfDocument.Form.Fields.Add(nameField);
    // Save the PDF document
    pdfDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}