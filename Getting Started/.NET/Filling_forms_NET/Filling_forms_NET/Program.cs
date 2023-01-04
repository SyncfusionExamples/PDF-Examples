
using Syncfusion.Pdf.Parsing;

//Load the PDF document.
FileStream docStream = new FileStream("../../../Data/Form.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);


