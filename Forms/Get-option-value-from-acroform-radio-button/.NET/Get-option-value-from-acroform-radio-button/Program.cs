using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
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

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

