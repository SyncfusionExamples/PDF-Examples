using Syncfusion.Pdf.Parsing;

//Load an existing PDF file.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
//Subscribe to the document split event.
loadedDocument.DocumentSplitEvent += LoadDocument_DocumentSplitEvent;
void LoadDocument_DocumentSplitEvent(object sender, PdfDocumentSplitEventArgs args)
{
    //Save the resulting document.
    FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/" + Guid.NewGuid().ToString() + ".pdf"), FileMode.Create, FileAccess.ReadWrite);
    args.PdfDocumentData.CopyTo(outputStream);
    outputStream.Close();
}
//Spit the document by ranges.
loadedDocument.SplitByRanges(new int[,] { { 0, 5 }, { 5, 10 } });

//Close the document.
loadedDocument.Close(true);