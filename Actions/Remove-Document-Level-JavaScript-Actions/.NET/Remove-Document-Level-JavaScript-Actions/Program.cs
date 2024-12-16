
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Load an existing PDF document using a file stream
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data\Input.pdf"), FileMode.Open, FileAccess.Read))
using (PdfLoadedDocument document = new PdfLoadedDocument(inputStream))
{
    //Retrieve the JavaScript collection from the document
    PdfDocumentJavaScriptCollection javaScriptCollection = document.DocumentJavaScripts;

    //Access the first JavaScript action in the collection
    PdfJavaScriptAction javaScriptAction = javaScriptCollection[0];

    //Remove the selected JavaScript action from the collection
    javaScriptCollection.Remove(javaScriptAction);

    //Save the modified document using a file stream
    using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output\Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        document.Save(outputStream);
    }
}