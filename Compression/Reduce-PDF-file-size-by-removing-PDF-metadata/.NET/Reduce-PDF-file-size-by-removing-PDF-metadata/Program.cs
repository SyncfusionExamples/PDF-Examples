﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Create a new compression option.
PdfCompressionOptions options = new PdfCompressionOptions();

//Set to remove the metadata information.
options.RemoveMetadata = true;

//Assign the compression option to the document
loadedDocument.Compress(options);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);