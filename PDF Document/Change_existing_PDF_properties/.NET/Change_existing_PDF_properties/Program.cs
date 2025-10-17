using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Modify the document information.
    loadedDocument.DocumentInformation.Author = "Syncfusion";
    loadedDocument.DocumentInformation.CreationDate = DateTime.Now;
    loadedDocument.DocumentInformation.Creator = "Essential PDF";
    loadedDocument.DocumentInformation.Keywords = "PDF";
    loadedDocument.DocumentInformation.Subject = "Document information DEMO";
    loadedDocument.DocumentInformation.Title = "Essential PDF Sample";
    loadedDocument.DocumentInformation.ModificationDate = DateTime.Now;
    loadedDocument.DocumentInformation.Producer = "Syncfusion PDF";

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}