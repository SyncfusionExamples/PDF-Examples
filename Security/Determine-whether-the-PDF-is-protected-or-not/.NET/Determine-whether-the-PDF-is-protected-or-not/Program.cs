using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

try
{
    //Load the PDF document.
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

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