// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Security;

//Create a new pdf document.
PdfDocument document = new PdfDocument();

//Adds a new page.
PdfPage page = document.Pages.Add();

//Creates a digital signature.
PdfSignature signature = new PdfSignature(page, "Signature");

//Add the time stamp by using the server URI.
signature.TimeStampServer = new TimeStampServer(new Uri("http://time.certum.pl/"));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

