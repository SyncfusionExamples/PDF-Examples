using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Load an existing PDF document
using (PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Retrieve the JavaScript collection from the document
    PdfDocumentJavaScriptCollection javaScriptCollection = document.DocumentJavaScripts;

    //Access the first JavaScript action in the collection
    PdfJavaScriptAction javaScriptAction = javaScriptCollection[0];

    //Remove the selected JavaScript action from the collection
    javaScriptCollection.Remove(javaScriptAction);

    //Save the modified document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}