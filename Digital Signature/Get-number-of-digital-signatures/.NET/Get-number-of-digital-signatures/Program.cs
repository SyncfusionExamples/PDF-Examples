using Syncfusion.Pdf.Parsing;

// Initialize a counter to count the number of signature fields in the PDF document
int signedFieldsCount = 0;
int unSignedFieldsCount = 0;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Access the form inside the loaded PDF document
    PdfLoadedForm form = loadedDocument.Form;
    // Iterate through each field in the form field collection
    foreach (PdfLoadedField field in form.Fields)
    {
        PdfLoadedSignatureField sigField = field as PdfLoadedSignatureField;
        // Check whether the signature field is signed or not
        if (sigField != null)
        {
            if (sigField.IsSigned)
            {
                signedFieldsCount++;
            }
            else
            {
                unSignedFieldsCount++;
            }
        }
    }
    // Display the total number of signature fields found in the PDF document
    Console.WriteLine("The number of signed signature fields in the PDF document: " + signedFieldsCount);
    Console.WriteLine("The number of unSigned signature fields in the PDF document: " + unSignedFieldsCount);
}