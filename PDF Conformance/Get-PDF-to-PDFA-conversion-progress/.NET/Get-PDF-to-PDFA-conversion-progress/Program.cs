using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
 
//Load an existing PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
 
//Subscribe to the PdfAConversionProgress event to track the PDF to PDF/A conversion process
loadedDocument.PdfAConversionProgress += new PdfLoadedDocument.PdfAConversionProgressEventHandler(pdfAConversion_TrackProgress);
 
loadedDocument.ConvertToPDFA(PdfConformanceLevel.Pdf_A1B);
 
//Save the document
loadedDocument.Save(Path.GetFullPath(@"Output.pdf"));
 
//Close the document
loadedDocument.Close(true);

//Event handler for Track PDF to PDF/A conversion process
void pdfAConversion_TrackProgress(object sender, PdfAConversionProgressEventArgs arguments)
{
    Console.WriteLine(String.Format("PDF to PDF/A conversion process " + arguments.ProgressValue + "% completed"));
}