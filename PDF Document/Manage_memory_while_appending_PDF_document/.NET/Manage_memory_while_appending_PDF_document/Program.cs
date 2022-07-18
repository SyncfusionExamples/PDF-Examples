// See https://aka.ms/new-console-template for more information

//Get file stream from an existing PDF document
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

FileStream fileStreamPath = new FileStream(Path.GetFullPath(@"../../../File1.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStreamPath);

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Enable memory optimization.
document.EnableMemoryOptimization = true;

//Append the document with source document.
document.Append(loadedDocument);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream
    document.Save(outputFileStream);
}

//Close the document
document.Close(true);


