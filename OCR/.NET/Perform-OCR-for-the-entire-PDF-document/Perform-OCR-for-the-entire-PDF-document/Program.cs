// See https://aka.ms/new-console-template for more information

using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;

// Initialize the OCR processor
using (OCRProcessor processor = new OCRProcessor())
{
    // Load the existing PDF document
    using (FileStream stream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open))
    {    
      PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(stream);
      
      // Set OCR language to process
      processor.Settings.Language = Languages.English;
      
      // Process OCR by providing the PDF document
      processor.PerformOCR(pdfLoadedDocument);
      
      //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        pdfLoadedDocument.Save(outputFileStream);
    }
      //Close the document.
      pdfLoadedDocument.Close(true);
    }    
}