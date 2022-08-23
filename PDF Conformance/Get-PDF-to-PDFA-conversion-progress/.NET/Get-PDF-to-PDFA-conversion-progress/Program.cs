// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load an existing PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Set the conformance for PDF/A-1b conversion.
loadedDocument.Conformance = PdfConformanceLevel.Pdf_A1B;

loadedDocument.PdfAConversionProgress += pdfAConversion_TrackProgress;

//Event handler for Track PDF to PDF/A conversion process
void pdfAConversion_TrackProgress(object sender, PdfAConversionProgressEventArgs arguments)
{
    Console.WriteLine(String.Format("PDF to PDF/A conversion process " + arguments.ProgressValue + "% completed"));
    Console.ReadLine();
}

