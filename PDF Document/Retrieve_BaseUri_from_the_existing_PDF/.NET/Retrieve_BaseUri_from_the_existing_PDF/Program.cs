// See https://aka.ms/new-console-template for more information


using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.
FileStream fileStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load a PDF document.
PdfLoadedDocument document = new PdfLoadedDocument(fileStream);

//Get the Base URI.
string baseUri = document.BaseUri;

//Close the document.
document.Close(true);