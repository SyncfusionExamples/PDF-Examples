using Syncfusion.Pdf.Parsing;

// Initialize a counter to count the number of signature fields in the PDF document
int count = 0; 

// Open the PDF document as a file stream
using (FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the PDF document from the file stream
    using (PdfLoadedDocument doc = new PdfLoadedDocument(docStream))
    {
        // Access the form inside the loaded PDF document
        PdfLoadedForm form = doc.Form;

        // Retrieve the collection of form fields present in the form
        PdfLoadedFormFieldCollection fieldCollection = form.Fields as PdfLoadedFormFieldCollection;

        // Iterate through each field in the form field collection
        foreach (PdfLoadedField field in fieldCollection)
        {
            // Check if the field is a signature field
            if (field is PdfLoadedSignatureField)
            {
                // Increment the counter if a signature field is found
                count++; 
            }
        }

        // Display the total number of signature fields found in the PDF document
        Console.WriteLine("The number of signature fields in the PDF document: " + count);
    }
}