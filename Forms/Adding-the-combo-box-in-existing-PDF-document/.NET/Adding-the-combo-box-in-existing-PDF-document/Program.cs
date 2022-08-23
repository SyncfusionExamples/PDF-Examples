// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Create the form if the form does not exist in the loaded document.
if (loadedDocument.Form == null)
    loadedDocument.CreateForm();

//Load the page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Create a combo box for the first page.
PdfComboBoxField comboBoxField = new PdfComboBoxField(loadedPage, "JobTitle");

//Set the combo box properties.
comboBoxField.Bounds = new Syncfusion.Drawing.RectangleF(40, 40, 100, 20);

//Set tooltip.
comboBoxField.ToolTip = "Job Title";

//Add list items.
comboBoxField.Items.Add(new PdfListFieldItem("Development", "accounts"));
comboBoxField.Items.Add(new PdfListFieldItem("Support", "advertise"));
comboBoxField.Items.Add(new PdfListFieldItem("Documentation", "content"));

//Add combo box to the form.
loadedDocument.Form.Fields.Add(comboBoxField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
