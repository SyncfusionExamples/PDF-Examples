﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Load an existing PDF file.
PdfLoadedDocument loadDocument = new PdfLoadedDocument(new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open));
//Subscribe to the document split event.
loadDocument.DocumentSplitEvent += LoadDocument_DocumentSplitEvent;
void LoadDocument_DocumentSplitEvent(object sender, PdfDocumentSplitEventArgs args)
{
    //Save the resulting document.
    FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/" + Guid.NewGuid().ToString() + ".pdf"), FileMode.Create, FileAccess.ReadWrite);
    args.PdfDocumentData.CopyTo(outputStream);
    outputStream.Close();
}
//Spit the document by a fixed number.
loadDocument.SplitByFixedNumber(2);

//Close the document.
loadDocument.Close(true);
