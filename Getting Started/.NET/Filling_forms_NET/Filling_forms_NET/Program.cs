using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Loads the form.
    PdfLoadedForm form = loadedDocument.Form;

    //Fills the textbox field by using index.
    (form.Fields[0] as PdfLoadedTextBoxField).Text = "John";

    //Fills the textbox fields by using field name.
    (form.Fields["Last Name"] as PdfLoadedTextBoxField).Text = "Doe";
    (form.Fields["Address"] as PdfLoadedTextBoxField).Text = " John Doe \n 123 Main St \n Anytown, USA";

    //Loads the radio button group.
    PdfLoadedRadioButtonItemCollection radioButtonCollection = (form.Fields["Gender"] as PdfLoadedRadioButtonListField).Items;

    //Checks the 'Male' option.
    radioButtonCollection[0].Checked = true;

    //Loads the radio button group.
    PdfLoadedRadioButtonItemCollection radioButtonCollection1 = (form.Fields["Occupation"] as PdfLoadedRadioButtonListField).Items;

    //Checks the 'Male' option.
    radioButtonCollection1[0].Checked = true;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}


