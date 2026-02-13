using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

// Load an existing PDF
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Access the document security settings
    PdfSecurity security = loadedDocument.Security;
    // Get the permission flags (bitwise enum)
    PdfPermissionsFlags permissions = security.Permissions;
    Console.WriteLine("Permissions in the document:");
    // Enumerate all flags and print the enabled ones
    foreach (PdfPermissionsFlags flag in Enum.GetValues(typeof(PdfPermissionsFlags)))
    {
        if (flag == 0) continue; // Skip None (0)
        // Check whether the specific flag is set
        if (permissions.HasFlag(flag))
        {
            Console.WriteLine($"- {flag}");
        }
    }
}
