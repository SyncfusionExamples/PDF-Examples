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

    //Create list box.
    PdfListBoxField listBoxField = new PdfListBoxField(loadedPage, "list1");

    //Set the properties.
    listBoxField.Bounds = new Syncfusion.Drawing.RectangleF(100, 60, 100, 50);

    //Add the items to the list box.
    listBoxField.Items.Add(new PdfListFieldItem("English", "English"));
    listBoxField.Items.Add(new PdfListFieldItem("French", "French"));
    listBoxField.Items.Add(new PdfListFieldItem("German", "German"));

    //Select the item.
    listBoxField.SelectedIndex = 2;

    //Set the multi select option.
    listBoxField.MultiSelect = true;

    //Add the list box into PDF document
    loadedDocument.Form.Fields.Add(listBoxField);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}