using Syncfusion.Pdf.Parsing;

// Initialize a counter to count the number of signature fields in the PDF document
int signedFieldsCount = 0;
int unSignedFieldsCount = 0;

// Open the PDF document as a file stream
using (FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the PDF document from the file stream
    using (PdfLoadedDocument doc = new PdfLoadedDocument(docStream))
    {
        // Access the form inside the loaded PDF document
        PdfLoadedForm form = doc.Form;

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
}