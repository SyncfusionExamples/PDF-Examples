using Syncfusion.Pdf;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Set the Base URI.
    document.BaseUri = "https://www.syncfusion.com/";

    //Create a new page.
    PdfPage page = document.Pages.Add();

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

