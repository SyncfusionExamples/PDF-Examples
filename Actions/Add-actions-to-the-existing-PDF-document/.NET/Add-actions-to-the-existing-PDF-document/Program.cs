using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{

    //Create JavaScript action.
    PdfJavaScriptAction scriptAction = new PdfJavaScriptAction("app.alert(\"Hello World!!!\")");

    //Add the JavaScript action.
    loadedDocument.Actions.AfterOpen = scriptAction;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
