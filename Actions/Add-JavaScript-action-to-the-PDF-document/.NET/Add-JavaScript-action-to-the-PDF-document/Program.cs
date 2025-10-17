using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Create JavaScript action.
    PdfJavaScriptAction scriptAction = new PdfJavaScriptAction("app.alert(\"Hello World!!!\")");

    //Add the JavaScript action.
    document.Actions.AfterOpen = scriptAction;

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

