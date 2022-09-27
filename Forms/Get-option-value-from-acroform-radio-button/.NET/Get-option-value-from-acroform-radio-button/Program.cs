// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Gets the loaded form.
PdfLoadedForm form = loadedDocument.Form;

//Set default appearance to false.
form.SetDefaultAppearance(false);

//Gets the 'Gender' radio button field.
PdfLoadedRadioButtonListField radioButtonField = form.Fields["SF182[0].#subform[0].P1BCheck[0]"] as PdfLoadedRadioButtonListField;

//Select the item that contains option value as "Male".
foreach (PdfLoadedRadioButtonItem item in radioButtonField.Items)
{
    //Gets an option value of the item.
    if (item.OptionValue == "Resubmission")
    {
        item.Selected = true;
    }

}

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);

