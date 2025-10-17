using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    //Create a new PdfButtonField with the properties.  
    PdfButtonField submitButton = new PdfButtonField(page, "submitButton");
    submitButton.Bounds = new RectangleF(25, 160, 100, 20);
    submitButton.Text = "Apply";
    submitButton.BackColor = new PdfColor(181, 191, 203);

    //Create a new PdfJavaScriptAction.
    PdfJavaScriptAction scriptAction = new PdfJavaScriptAction("app.alert(\"You are looking at Form field action of PDF \")");

    //Set the scriptAction to submitButton.
    submitButton.Actions.MouseDown = scriptAction;

    //Add the submit button to the new document.
    document.Form.Fields.Add(submitButton);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}