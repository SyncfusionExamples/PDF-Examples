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

    //Create a Button and set properties to the Button field.
    PdfButtonField buttonField = new PdfButtonField(loadedPage, "Click");
    buttonField.Bounds = new Syncfusion.Drawing.RectangleF(0, 0, 90, 20);
    buttonField.Text = "Click";

    //Add the form field to the existing document.
    loadedDocument.Form.Fields.Add(buttonField);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

