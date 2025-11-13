using Syncfusion.Pdf.Parsing;

//Load the PDF document.
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Check if the document contains a form with fields
    if (loadedDocument.Form == null || loadedDocument.Form.Fields.Count == 0)
    {
        Console.WriteLine("No signature fields found in the document.");
    }
    else
    {
        // Iterate through all fields in the form
        foreach (PdfLoadedField field in loadedDocument.Form.Fields)
        {
            // Check if the field is a signature field
            PdfLoadedSignatureField signatureField = field as PdfLoadedSignatureField;
            if (signatureField != null)
            {
                // Determine whether the signature field is signed or not
                string status = signatureField.IsSigned ? "Signed" : "UnSigned";

                // Output the result for each signature field
                Console.WriteLine("Signature Field " + signatureField.Name + " is: " + status);
            }
        }
    }
    //Save the PDF document 
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}