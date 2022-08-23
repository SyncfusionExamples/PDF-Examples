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

//Create Check Box field.
PdfCheckBoxField checkBoxField = new PdfCheckBoxField(loadedPage, "CheckBox");

//Set check box properties.
checkBoxField.ToolTip = "Check Box";
checkBoxField.Bounds = new Syncfusion.Drawing.RectangleF(0, 20, 10, 10);

//Add the form field to the existing document.
loadedDocument.Form.Fields.Add(checkBoxField);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);


