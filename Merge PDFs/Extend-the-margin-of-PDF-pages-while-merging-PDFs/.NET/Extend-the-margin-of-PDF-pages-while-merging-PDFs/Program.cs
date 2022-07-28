// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document. 
PdfDocument finalDoc = new PdfDocument();

//Create new instance for the document margin.
PdfMargins margin = new PdfMargins();
margin.All = 40;

//Set margin.
finalDoc.PageSettings.Margins = margin;

//Get stream from the PDF documents. 
FileStream stream1 = new FileStream(Path.GetFullPath("../../../File1.pdf"), FileMode.Open, FileAccess.Read);
FileStream stream2 = new FileStream(Path.GetFullPath("../../../File2.pdf"), FileMode.Open, FileAccess.Read);

//Create a PDF stream for merging.
Stream[] streams = { stream1, stream2 };

//Create merging options.
PdfMergeOptions mergeOptions = new PdfMergeOptions();

//Enable the Extend Margin
mergeOptions.ExtendMargin = true;

//Merge PDFDocument.
PdfDocumentBase.Merge(finalDoc, mergeOptions, streams);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    finalDoc.Save(outputFileStream);
}

//Close the documents.

finalDoc.Close(true);
