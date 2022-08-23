// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new page to PDF document.
PdfPage page = document.Pages.Add();

//Create a combo box for the first page.
PdfComboBoxField comboBoxField = new PdfComboBoxField(page, "JobTitle");

//Set the combo box properties.
comboBoxField.Bounds = new Syncfusion.Drawing.RectangleF(0, 40, 100, 20);

//Set tooltip.
comboBoxField.ToolTip = "Job Title";

//Add list items.
comboBoxField.Items.Add(new PdfListFieldItem("Development", "accounts"));
comboBoxField.Items.Add(new PdfListFieldItem("Support", "advertise"));
comboBoxField.Items.Add(new PdfListFieldItem("Documentation", "content"));

//Add combo box to the form.
document.Form.Fields.Add(comboBoxField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);