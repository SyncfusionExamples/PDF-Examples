using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load an existing PDF document
using (PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Retrieve the JavaScript collection from the loaded document
    PdfDocumentJavaScriptCollection javaScriptCollection = document.DocumentJavaScripts;

    //Iterate through the JavaScript actions in the collection
    foreach (PdfJavaScriptAction action in javaScriptCollection)
    {
        //Display the name of the JavaScript action
        Console.WriteLine($"Action Name: {action.Name}");

        //Display the JavaScript code associated with the action
        Console.WriteLine($"JavaScript Code: {action.JavaScript}");
    }
}
