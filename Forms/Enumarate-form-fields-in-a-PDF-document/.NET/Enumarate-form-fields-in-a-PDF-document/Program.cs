// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Get the loaded form.
PdfLoadedForm form = document.Form;

//Get the form field collection. 
PdfLoadedFormFieldCollection fields = form.Fields;

//Enumerates the form fields.
for (int i = 0; i < fields.Count; i++)
{
    if (fields[i] is PdfLoadedTextBoxField)
    {
        //Get the loaded textbox field and fill it.
        PdfLoadedTextBoxField loadedTextBoxField = fields[i] as PdfLoadedTextBoxField;
        loadedTextBoxField.Text = "Text";
    }
}

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);