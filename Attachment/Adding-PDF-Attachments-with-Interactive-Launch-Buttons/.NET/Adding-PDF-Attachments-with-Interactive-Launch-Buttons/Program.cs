using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the first page of the PDF
    PdfLoadedPage lpage = loadedDocument.Pages[0] as PdfLoadedPage;

    // Create a PDF attachment
    PdfAttachment attachment = new PdfAttachment("Attachment.pdf", File.ReadAllBytes(Path.GetFullPath(@"Data/Attachment.pdf")));
    attachment.Description = "PDF Attachment";

    // Create attachments section if it doesn't exist
    if (loadedDocument.Attachments == null)
        loadedDocument.CreateAttachment();

    // Add the attachment to the document
    loadedDocument.Attachments.Add(attachment);

    // Create a button field on the page
    PdfButtonField buttonField = new PdfButtonField(lpage, "Button");
    buttonField.Bounds = new RectangleF(100, 100, 100, 20);
    buttonField.BorderColor = new PdfColor(Color.Black);
    buttonField.BackColor = new PdfColor(Color.LightGray);
    buttonField.Text = "Click Me";
    buttonField.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

    // Add JavaScript action to open the attachment
    buttonField.Actions.MouseUp = new PdfJavaScriptAction("this.exportDataObject({ cName: \"Attachment.pdf\", nLaunch: 2 });");

    // Create a form if it doesn't exist
    if (loadedDocument.Form == null)
        loadedDocument.CreateForm();

    // Add the button field to the form
    loadedDocument.Form.Fields.Add(buttonField);

    // Set default appearance for form fields
    loadedDocument.Form.SetDefaultAppearance(false);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
