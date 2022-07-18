// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.  
FileStream fileStreamPath = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load the PDF document. 
PdfLoadedDocument document = new PdfLoadedDocument(fileStreamPath);

//Modify the document information.
document.DocumentInformation.Author = "Syncfusion";
document.DocumentInformation.CreationDate = DateTime.Now;
document.DocumentInformation.Creator = "Essential PDF";
document.DocumentInformation.Keywords = "PDF";
document.DocumentInformation.Subject = "Document information DEMO";
document.DocumentInformation.Title = "Essential PDF Sample";
document.DocumentInformation.ModificationDate = DateTime.Now;
document.DocumentInformation.Producer = "Syncfusion PDF";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document.
    document.Save(outputFileStream);
}

//Closes the PDF document
document.Close(true);