using Syncfusion.Pdf;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add new PDF page.
    PdfPage page = document.Pages.Add();

    //Add Custom MetaData.
    document.DocumentInformation.CustomMetadata["ID"] = "IO1";
    document.DocumentInformation.CustomMetadata["CompanyName"] = "Syncfusion";
    document.DocumentInformation.CustomMetadata["Key"] = "DocumentKey";

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

