// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

// Open a file stream to read the input PDF file.
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Data/imageDoc.pdf"), FileMode.Open, FileAccess.Read))
{ 
    // Create a new PdfLoadedDocument object from the file stream.
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream))
    { 
        // Create a new PdfCompressionOptions object.
        PdfCompressionOptions options = new PdfCompressionOptions(); 
        
        // Enable image compression and set image quality.
        options.CompressImages = true; 
        options.ImageQuality = 50; 
        
        // Enable font optimization.
        options.OptimizeFont = true; 
        
        // Enable page content optimization.
        options.OptimizePageContents = true; 
        
        // Remove metadata from the PDF.
        options.RemoveMetadata = true; 
        
        // Compress the PDF document.
        loadedDocument.Compress(options);

        //Create file stream.
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
        {
            //Save the PDF document to file stream.
            loadedDocument.Save(outputFileStream);
        }
        //Close the document.
        loadedDocument.Close(true);
    }
} 

