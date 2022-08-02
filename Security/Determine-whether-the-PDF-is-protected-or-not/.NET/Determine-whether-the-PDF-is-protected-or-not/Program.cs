// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

try
{
    //Get stream from an existing document. 
    FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

    //Load the PDF document.
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream, "password");

	//Write whether document is protected or not in console window. 
    Console.WriteLine("The PDF document is password protected one");
}

catch (PdfDocumentException exception)
{
    //Write whether document is protected or not in console window. 
    Console.WriteLine("The PDF document is not password protected");
}

Console.ReadLine();