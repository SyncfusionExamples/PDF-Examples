using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;

// Load signed PDF
using (PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the PDF form
    PdfLoadedForm form = document.Form;

    if (form != null && form.Fields != null && form.Fields.Count > 0)
    {
        foreach (PdfLoadedField field in form.Fields)
        {
            // Check for signature field
            if (field is PdfLoadedSignatureField signatureField && signatureField.IsSigned)
            {
                // Validate signature
                PdfSignatureValidationResult result = signatureField.ValidateSignature();

                if (result?.Certificates != null && result.Certificates.Count > 0)
                {
                    X509Certificate2 certificate = result.Certificates[0];

                    string policyId = GetCertificatePolicyOID(certificate);

                    if (!string.IsNullOrEmpty(policyId))
                    {
                        Console.WriteLine($"Policy OID: {policyId}");

                        string certClass = MapCertificateClass(policyId);
                        Console.WriteLine($"Certificate Type: {certClass}");
                    }
                    else
                    {
                        Console.WriteLine("❌ Certificate policy not found.");
                    }

                    Console.WriteLine("-----------------------------------");
                }
            }
        }
    }
}

// Extract Certificate Policy OID (2.5.29.32)
string GetCertificatePolicyOID(X509Certificate2 certificate)
{
    foreach (X509Extension extension in certificate.Extensions)
    {
        if (extension?.Oid?.Value == "2.5.29.32")
        {
            string formatted = extension.Format(true);

            // Example format contains: "Policy Identifier=OID"
            return ExtractPolicyID(formatted);
        }
    }
    return null;
}

// Extracts Policy Identifier from formatted string
string ExtractPolicyID(string policyText)
{
    if (string.IsNullOrEmpty(policyText))
        return null;
    const string keyword = "Policy Identifier=";
    int index = policyText.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);
    if (index < 0)
        return null;
    index += keyword.Length;
    int endIndex = policyText.IndexOf(",", index);
    string rawOid;
    if (endIndex > index)
        rawOid = policyText.Substring(index, endIndex - index);
    else
        rawOid = policyText.Substring(index);
    // Clean unwanted characters
    return CleanOID(rawOid);
}

string CleanOID(string oid)
{
    if (string.IsNullOrEmpty(oid))
        return null;

    // Remove line breaks, tabs, spaces
    oid = oid.Replace("\r", "")
             .Replace("\n", "")
             .Replace("\t", "")
             .Trim();

    // Remove anything after invalid characters like '['
    int index = oid.IndexOfAny(new char[] { '[', ' ' });
    if (index > 0)
        oid = oid.Substring(0, index);

    return oid.Trim();
}

// Map OID to Certificate Type
string MapCertificateClass(string oid)
{
    switch (oid)
    {
        case "2.16.356.100.2.1":
            return "Class 1 Certificate";

        case "2.16.356.100.2.2":
            return "Class 2 Certificate";

        case "2.16.356.100.2.3":
            return "Class 3 Certificate";

        case "2.16.840.1.114028.10.1.6":
            return "DocuSign High Assurance (Equivalent to Class 3)";

        default:
            return "Unknown / Custom Certificate Policy";
    }
}