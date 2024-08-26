// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.  
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

document.OnPdfPassword += Document_OnPdfPassword;

//Accessing the attachments.
foreach (PdfAttachment attachment in document.Attachments)
{
    FileStream stream = new FileStream(attachment.FileName, FileMode.Create);

    stream.Write(attachment.Data, 0, attachment.Data.Length);

    stream.Dispose();
}
Console.WriteLine("Successfully set user password when accessing the attachment");

//Close the document.
document.Close(true);

//Provide the user password in event. 
void Document_OnPdfPassword(object sender, OnPdfPasswordEventArgs args)
{
    args.UserPassword = "syncfusion";
}