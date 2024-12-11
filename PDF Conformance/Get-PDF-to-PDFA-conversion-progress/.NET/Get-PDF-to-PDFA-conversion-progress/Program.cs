// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
 
//Load an existing PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
 
//Subscribe to the PdfAConversionProgress event to track the PDF to PDF/A conversion process
loadedDocument.PdfAConversionProgress += new PdfLoadedDocument.PdfAConversionProgressEventHandler(pdfAConversion_TrackProgress);
 
loadedDocument.ConvertToPDFA(PdfConformanceLevel.Pdf_A1B);
 
//Save the document
FileStream outputStream = new FileStream(Path.GetFullPath(@"Output.pdf"), FileMode.Create, FileAccess.Write);
loadedDocument.Save(outputStream);
 
//Close the document
loadedDocument.Close(true);
 
 
//Event handler for Track PDF to PDF/A conversion process
void pdfAConversion_TrackProgress(object sender, PdfAConversionProgressEventArgs arguments)
{
    Console.WriteLine(String.Format("PDF to PDF/A conversion process " + arguments.ProgressValue + "% completed"));
}