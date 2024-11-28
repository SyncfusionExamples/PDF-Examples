// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

// Load an existing PDF document
using (FileStream inputPdfStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Initialize PdfLoadedDocument with the input file stream
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputPdfStream);

    // Convert the loaded document to PDF/A format with specified conformance level
    loadedDocument.ConvertToPDFA(PdfConformanceLevel.Pdf_A1B);

    // Save the converted PDF/A document to a new file
    using (FileStream outputPdfStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
    {
        // Save the modified PDF document to the output file stream
        loadedDocument.Save(outputPdfStream);
    }

    // Close the loaded document to release resources
    loadedDocument.Close(true);
}