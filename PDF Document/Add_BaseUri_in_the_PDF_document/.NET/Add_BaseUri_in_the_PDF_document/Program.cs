// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;

//Create a new instance of the PdfDocument class.
PdfDocument document = new PdfDocument();

//Set the Base URI.
document.BaseUri = "https://www.syncfusion.com/";

//Create a new page.
PdfPage page = document.Pages.Add();

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

