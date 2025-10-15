using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Set the default appearance of the PDF form.
    loadedDocument.Form.SetDefaultAppearance(true);

    //Get the loaded form.
    PdfLoadedForm loadedForm = loadedDocument.Form;

    //Fill list box.
    PdfLoadedListBoxField loadedListBox = loadedForm.Fields[5] as PdfLoadedListBoxField;

    //Fill list box and Modify the list box select index.
    loadedListBox.SelectedIndex = new int[1] { 2 };

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
