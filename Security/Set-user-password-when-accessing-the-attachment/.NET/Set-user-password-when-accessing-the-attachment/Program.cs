using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document.
PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

document.OnPdfPassword += Document_OnPdfPassword;

//Accessing the attachments.
foreach (PdfAttachment attachment in document.Attachments)
{
    FileStream stream = new FileStream(Path.GetFullPath(@"Output/") + attachment.FileName, FileMode.Create);

    stream.Write(attachment.Data, 0, attachment.Data.Length);

    stream.Dispose();
}

//Close the document.
document.Close(true);

//Provide the user password in event. 
void Document_OnPdfPassword(object sender, OnPdfPasswordEventArgs args)
{
    args.UserPassword = "syncfusion";
}