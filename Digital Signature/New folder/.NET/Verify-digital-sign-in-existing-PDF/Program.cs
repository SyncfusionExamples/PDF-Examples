using System;
using System.IO;
using System.Reflection.Metadata;
using Syncfusion.Pdf.Parsing;


// Open the signed PDF file for reading
using (FileStream inputFileStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the PDF document
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);

    // Check if the document has a form (which would contain signature fields)
    if (loadedDocument.Form == null)
    {
        Console.WriteLine("No signature fields found in the document.");
        return;
    }

    // Iterate through all fields in the form
    foreach (var field in loadedDocument.Form.Fields)
    {
        // Check if the field is a signature field
        if (field is PdfLoadedSignatureField signatureField)
        {
            // Determine whether the signature field is signed or not
            string status = signatureField.IsSigned ? "Signed" : "UnSigned";

            // Output the result for each signature field
            Console.WriteLine($"Signature Field {signatureField.Name} is : {status}");
        }
    }
    //Close the document
    loadedDocument.Close(true);
}