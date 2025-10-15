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

    //Create Check Box field.
    PdfCheckBoxField checkBoxField = new PdfCheckBoxField(loadedPage, "CheckBox");

    //Set check box properties.
    checkBoxField.ToolTip = "Check Box";
    checkBoxField.Bounds = new Syncfusion.Drawing.RectangleF(0, 20, 10, 10);

    //Add the form field to the existing document.
    loadedDocument.Form.Fields.Add(checkBoxField);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}


