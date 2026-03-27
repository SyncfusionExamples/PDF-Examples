// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System.IO;

FileStream fileStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
// Load the PDF document
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream);
// Access the existing form fields
PdfLoadedForm form = loadedDocument.Form;
// Iterate through the fields
foreach (PdfLoadedField field in form.Fields)
{
    // Check for checkbox fields
    if (field is PdfLoadedCheckBoxField checkBoxField)
    {
        checkBoxField.ForeColor = Color.Red; // Set desired color
    }
    // Check for radio button fields
    else if (field is PdfLoadedRadioButtonListField radioButtonField)
    {
        foreach (PdfLoadedRadioButtonItem item in radioButtonField.Items)
        {
            item.ForeColor = Color.Blue; // Set desired color
        }
    }
}

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
