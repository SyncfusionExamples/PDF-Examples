using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

// Create a new PDF document
using (PdfDocument pdfDocument = new PdfDocument())
{
    // Add a new page to the PDF document
    PdfPage pdfPage = pdfDocument.Pages.Add();
    // Create a standard font
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
    // Draw the title text on the page
    pdfPage.Graphics.DrawString("Job Application", font, PdfBrushes.Black, new PointF(250, 0));
    // Change the font size for form field labels
    font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
    // Draw the label "Name" on the page
    pdfPage.Graphics.DrawString("Name", font, PdfBrushes.Black, new PointF(10, 20));
    // Create a text box field for entering the name
    PdfTextBoxField nameField = new PdfTextBoxField(pdfPage, "Name");
    nameField.Bounds = new RectangleF(10, 40, 200, 20);
    nameField.ToolTip = "Name";
    // Add the field to the form
    pdfDocument.Form.Fields.Add(nameField); 
    // Draw the label "Email address" on the page
    pdfPage.Graphics.DrawString("Email address", font, PdfBrushes.Black, new PointF(10, 80));
    // Create a text box field for entering the email address
    PdfTextBoxField emailField = new PdfTextBoxField(pdfPage, "Email address");
    emailField.Bounds = new RectangleF(10, 100, 200, 20);
    emailField.ToolTip = "Email address";
    // Add the field to the form
    pdfDocument.Form.Fields.Add(emailField); 
    // Save the PDF document
    pdfDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}