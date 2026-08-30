using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Get the stream from the document
using (FileStream documentStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the signed PDF document
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(documentStream);

    // Get the PDF form
    PdfLoadedForm form = loadedDocument.Form;

    // Initialize flag to detect timestamp signatures
    bool isTimeStampSignature = false;

    // Loop through all form fields in reverse
    for (int i = form.Fields.Count - 1; i >= 0; i--)
    {
        PdfLoadedField field = form.Fields[i] as PdfLoadedField;

        // Check if the field is a signature field
        if (field is PdfLoadedSignatureField)
        {
            PdfLoadedSignatureField signatureField = field as PdfLoadedSignatureField;
            Console.WriteLine("Signature field name: " + signatureField.Name);

            // Validate the signature
            PdfSignatureValidationResult result = signatureField.ValidateSignature();

            if (result != null)
            {
                // Check if it's a timestamp signature
                if (result.TimeStampInformation != null && result.TimeStampInformation.IsDocumentTimeStamp)
                {
                    isTimeStampSignature = true;
                    Console.WriteLine("Signature is a time stamp signature.");
                }
                else
                {
                    bool isCAdES = false;

                    // Check if the cryptographic standard is CAdES
                    if (result.CryptographicStandard == CryptographicStandard.CADES)
                    {
                        isCAdES = true;
                    }

                    // Check if LTV (Long-Term Validation) is enabled
                    if (result.LtvVerificationInfo.IsLtvEnabled)
                    {
                        // Identify the type of long-term signature
                        if (isCAdES && isTimeStampSignature)
                        {
                            Console.WriteLine("LTA signature.");
                        }
                        else
                        {
                            Console.WriteLine("LTV signature.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No LTV signature.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Signature is not valid.");
            }
        }
    }
    // Close the PDF document.
    loadedDocument.Close(true);
}
