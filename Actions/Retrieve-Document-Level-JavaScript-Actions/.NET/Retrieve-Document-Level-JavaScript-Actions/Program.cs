using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load an existing PDF document using a file stream
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
using (PdfLoadedDocument document = new PdfLoadedDocument(fileStream))
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
