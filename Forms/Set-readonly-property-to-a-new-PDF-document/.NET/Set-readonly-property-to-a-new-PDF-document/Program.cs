using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a new page to PDF document.
    PdfPage page = document.Pages.Add();

    //Create the form.
    PdfForm form = document.Form;

    //Set the form as read only.
    form.ReadOnly = true;

    //Create a text box field and add the properties.
    PdfTextBoxField textBoxField = new PdfTextBoxField(page, "FirstName");
    textBoxField.Bounds = new RectangleF(0, 0, 100, 20);
    textBoxField.ToolTip = "First Name";
    textBoxField.Text = "john";

    //set read only property for a particular field
    //textBoxField.ReadOnly = true;

    //Add the form field to the document.
    document.Form.Fields.Add(textBoxField);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}