// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

try
{
    //Get stream from an existing document. 
    FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

    //Load the PDF document.
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

	//Write whether document is protected or not in console window. 
    Console.WriteLine("The PDF document is password protected one");
}

catch (PdfException exception)
{
    if (exception.Message == "Can't open an encrypted document. The password is invalid.")
    {
        Console.WriteLine("Cannot open an encrypted document without password");
    }
}
    
Console.ReadLine();