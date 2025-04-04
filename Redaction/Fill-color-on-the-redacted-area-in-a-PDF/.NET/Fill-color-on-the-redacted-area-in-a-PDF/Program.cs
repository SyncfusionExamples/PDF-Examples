﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Get stream from an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the first page from the document.
PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

//Create a PDF redaction for the page.
PdfRedaction redaction = new PdfRedaction(new RectangleF(343, 147, 60, 17));

//Set fill color for the redaction bounds.
redaction.FillColor = Color.Red;

//Add a redaction object into the redaction collection of loaded page.
page.AddRedaction(redaction);

//Redact the contents from the PDF document.
loadedDocument.Redact();

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
