using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the conformance level of the loaded document. 
    PdfConformanceLevel conformance = loadedDocument.Conformance;

    Console.WriteLine("Conformance level :" + conformance);
}
