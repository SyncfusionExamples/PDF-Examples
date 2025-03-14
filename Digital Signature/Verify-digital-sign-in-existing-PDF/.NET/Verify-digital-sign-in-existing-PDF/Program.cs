using System;
using System.IO;
using System.Reflection.Metadata;
using Syncfusion.Pdf.Parsing;


// Open the signed PDF file for reading
using (FileStream inputFileStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the PDF document
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);

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
    //Close the document
    loadedDocument.Close(true);
}