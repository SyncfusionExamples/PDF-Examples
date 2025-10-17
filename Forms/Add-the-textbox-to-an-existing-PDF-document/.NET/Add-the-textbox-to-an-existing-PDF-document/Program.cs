using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Create the form if the form does not exist in the loaded document.
    if (loadedDocument.Form == null)
        loadedDocument.CreateForm();

    //Load the page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create a textbox field and add the properties.
    PdfTextBoxField textBoxField = new PdfTextBoxField(loadedPage, "FirstName");
    textBoxField.Bounds = new Syncfusion.Drawing.RectangleF(0, 0, 100, 20);
    textBoxField.ToolTip = "First Name";

    //Add the form field to the existing PDF document.
    loadedDocument.Form.Fields.Add(textBoxField);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}