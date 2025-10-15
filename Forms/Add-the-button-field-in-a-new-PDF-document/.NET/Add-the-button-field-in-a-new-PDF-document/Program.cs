using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a new page to PDF document.
    PdfPage page = document.Pages.Add();

    //Create a Button.
    PdfButtonField buttonField = new PdfButtonField(page, "Click");

    //Set properties to the Button field.
    buttonField.Bounds = new Syncfusion.Drawing.RectangleF(0, 100, 90, 20);
    buttonField.Text = "Click";

    //Add the form field to the document.
    document.Form.Fields.Add(buttonField);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
