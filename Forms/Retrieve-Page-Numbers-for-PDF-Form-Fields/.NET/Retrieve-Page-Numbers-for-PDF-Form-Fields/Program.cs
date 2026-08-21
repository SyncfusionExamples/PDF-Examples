using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

// Load the PDF document from the stream.
PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

// Get all the form fields in the PDF.
PdfLoadedForm loadedForm = document.Form;
PdfLoadedFormFieldCollection fieldCollection = loadedForm.Fields;
// Create a dictionary to map each page object to its respective page number.
Dictionary<PdfPageBase, int> pageNumberMapping = new Dictionary<PdfPageBase, int>();
// Populate the pageNumberMapping dictionary with page objects and their corresponding page numbers.
for (int i = 0; i < document.Pages.Count; i++)
{
    // Page numbers are 1-based, so we add 1 to the index.
    pageNumberMapping[document.Pages[i]] = i + 1;
}
// Iterate through each form field and find its page number using the dictionary.
foreach (PdfLoadedField field in fieldCollection)
{
    // Check if the field is associated with a page.
    if (field.Page != null && pageNumberMapping.TryGetValue(field.Page, out int pageNumber))
    {
        // Output the field name and its associated page number.
        Console.WriteLine($"{field.Name} - Page number: {pageNumber}");
    }
}
// Close the PDF document.
document.Close(true);