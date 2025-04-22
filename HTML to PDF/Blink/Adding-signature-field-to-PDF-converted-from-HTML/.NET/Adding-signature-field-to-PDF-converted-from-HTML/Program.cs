using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Interactive;

internal class Program
{
    static void Main(string[] args)
    {
        // Initialize the HTML to PDF converter using the Blink rendering engine
        HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

        // Configure the converter to preserve form fields in the PDF
        BlinkConverterSettings settings = new BlinkConverterSettings
        {
            EnableForm = true // Ensures form elements like <input>, <textarea> are converted to PDF fields
        };
        htmlConverter.ConverterSettings = settings;

        // Convert the HTML file to a PDF document
        PdfDocument document = htmlConverter.Convert(Path.GetFullPath(@"Data/Test.html"));

        // Optional: Remove default appearances for form fields to match the page style
        document.Form.SetDefaultAppearance(false);

        // Save the PDF to a memory stream for further processing
        using (MemoryStream stream = new MemoryStream())
        {
            document.Save(stream);            // Save converted PDF to memory
            stream.Position = 0;              // Reset stream position
            document.Close(true);             // Close the original document

            // Replace the "signature" textarea with an actual signature field
            AddPdfSignatureField(stream);
        }
    }

    /// <summary>
    /// Finds the "signature" field in the form, removes it, and replaces it with a true PDF signature field.
    /// </summary>
    /// <param name="stream">MemoryStream containing the PDF document</param>
    static void AddPdfSignatureField(MemoryStream stream)
    {
        // Load the PDF document from memory stream
        using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream))
        {
            PdfLoadedForm loadedForm = loadedDocument.Form;

            // Check for a field named "signature"
            if (loadedForm.Fields["signature"] is PdfLoadedTextBoxField signatureTextBox)
            {
                // Get the original field's position and page
                RectangleF bounds = signatureTextBox.Bounds;
                PdfPageBase page = signatureTextBox.Page;

                // Remove the original textbox field
                loadedForm.Fields.Remove(signatureTextBox);

                // Create a new signature field at the same location
                PdfSignatureField signatureField = new PdfSignatureField(page, "ClientSignature")
                {
                    Bounds = bounds
                };

                // Add the new signature field to the form
                loadedForm.Fields.Add(signatureField);
            }

            // Save the modified document to disk
            using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
            {
                loadedDocument.Save(outputStream);
            }
            // Close the document and release resources
            loadedDocument.Close(true);
        }
    }
}