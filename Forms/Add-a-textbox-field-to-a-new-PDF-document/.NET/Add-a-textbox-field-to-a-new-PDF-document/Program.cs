// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

// Create a new PDF document
using (PdfDocument pdfDocument = new PdfDocument())
{
    // Add a new page to the PDF document
    PdfPage pdfPage = pdfDocument.Pages.Add();

    // Set the standard font
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);

    // Draw the string "Job Application"
    pdfPage.Graphics.DrawString("Job Application", font, PdfBrushes.Black, new PointF(250, 0));

    // Change the font size for the form fields
    font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

    // Draw the string "Name"
    pdfPage.Graphics.DrawString("Name", font, PdfBrushes.Black, new PointF(10, 20));

    // Create a text box field for name
    PdfTextBoxField nameField = new PdfTextBoxField(pdfPage, "Name");
    nameField.Bounds = new RectangleF(10, 40, 200, 20);
    nameField.ToolTip = "Name";
    pdfDocument.Form.Fields.Add(nameField);

    // Draw the string "Email address"
    pdfPage.Graphics.DrawString("Email address", font, PdfBrushes.Black, new PointF(10, 80));

    // Create a text box field for email address
    PdfTextBoxField emailField = new PdfTextBoxField(pdfPage, "Email address");
    emailField.Bounds = new RectangleF(10, 100, 200, 20);
    emailField.ToolTip = "Email address";
    pdfDocument.Form.Fields.Add(emailField);

    //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        pdfDocument.Save(outputFileStream);
    }
}