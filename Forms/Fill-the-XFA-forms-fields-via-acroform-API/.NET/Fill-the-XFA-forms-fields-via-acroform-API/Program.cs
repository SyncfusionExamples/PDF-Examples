using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the existing Acroform.
    PdfLoadedForm acroform = loadedDocument.Form;

    //Enable XFA form filling.
    acroform.EnableXfaFormFill = true;

    //Get the existing text box field named "FirstName".
    PdfLoadedTextBoxField firstName = acroform.Fields["FirstName"] as PdfLoadedTextBoxField;

    //Set text.
    firstName.Text = "Simon";

    //Get the existing text box field named "LastName".
    PdfLoadedTextBoxField lastName = acroform.Fields["LastName"] as PdfLoadedTextBoxField;

    //Set text.
    lastName.Text = "Bistro";

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
