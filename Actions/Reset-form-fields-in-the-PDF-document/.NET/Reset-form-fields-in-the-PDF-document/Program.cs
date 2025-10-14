using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a new page
    PdfPage page = document.Pages.Add();

    //Create a Text box field
    PdfTextBoxField textBoxField = new PdfTextBoxField(page, "FirstName");
    //Set properties to the textbox
    textBoxField.BorderColor = new PdfColor(Color.Gray);
    textBoxField.BorderStyle = PdfBorderStyle.Beveled;
    textBoxField.Bounds = new RectangleF(80, 0, 100, 20);
    textBoxField.Text = "First Name";

    //Add the form field to the document
    document.Form.Fields.Add(textBoxField);

    //Create a Button field.
    PdfButtonField clearButton = new PdfButtonField(page, "Clear");
    clearButton.Bounds = new RectangleF(100, 60, 50, 20);
    clearButton.ToolTip = "Clear";
    //Add button field to the form
    document.Form.Fields.Add(clearButton);

    //Create an instance of reset action
    PdfResetAction resetAction = new PdfResetAction();
    clearButton.Actions.GotFocus = resetAction;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
