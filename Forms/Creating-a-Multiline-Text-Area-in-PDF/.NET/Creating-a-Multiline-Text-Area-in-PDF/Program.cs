using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    // Creates a new page and adds it as the last page of the document
    PdfPage page = document.Pages.Add();
    // Create a standard font to be used in the text field
    PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 12f);
    // Create a text box field and add it to the page with a name
    PdfTextBoxField textBoxField = new PdfTextBoxField(page, "FirstName");
    // Set the bounds (position and size) of the text box field
    textBoxField.Bounds = new RectangleF(0, 0, 200, 50);

    // Enable multiline functionality for the text box (allows multiple lines of text)
    textBoxField.Multiline = true;

    // Set the initial text inside the text box field
    textBoxField.Text = "Essential PDF allows you to create and manage the form (AcroForm) in PDF document by using PdfForm class. The PdfFormFieldCollection class represents the entire field collection of the form.";
    // Add the text box field to the form field collection in the document
    document.Form.Fields.Add(textBoxField);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}