using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;

// Create a new PDF document instance.
PdfDocument document = new PdfDocument();

// Retrieve the JavaScript collection from the document.
PdfDocumentJavaScriptCollection javaScriptCollection = document.DocumentJavaScripts;

// Define a new JavaScript action that displays an alert with the message "Hello World!!!".
PdfJavaScriptAction javaScriptAction = new PdfJavaScriptAction("app.alert(\"Hello World!!!\")");

// Set the name of the JavaScript action.
javaScriptAction.Name = "Test";

// Add the JavaScript action to the document's JavaScript collection.
javaScriptCollection.Add(javaScriptAction);

// Save the PDF document using a file stream.
using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
{
    document.Save(fileStream);
}
// Close the document to release resources.
document.Close(true);