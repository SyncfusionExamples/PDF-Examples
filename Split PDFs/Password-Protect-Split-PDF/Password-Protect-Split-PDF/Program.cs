using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

// Create the FileStream object. 
using (FileStream inputFileStream = new FileStream("../../../Data/Input.pdf", FileMode.Open, FileAccess.Read))
{
    // Create a PdfLoadedDocument object from the FileStream object  
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream,"password");
    // Iterate over the pages in the PdfLoadedDocument object  
    for (int pageIndex = 0; pageIndex < loadedDocument.PageCount; pageIndex++)
    {
        // Create a new PdfDocument object  
        using (PdfDocument outputDocument = new PdfDocument())
        {
            // Import the page from the PdfLoadedDocument object to the PdfDocument object  
            outputDocument.ImportPage(loadedDocument, pageIndex);
            //Save the document into a filestream object. 
            using (FileStream outputFileStream = new FileStream("../../../Output" + pageIndex + ".pdf", FileMode.Create, FileAccess.Write))
            {
                outputDocument.Save(outputFileStream);
            }
        }
    }
}