using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page of the document.
    PdfPage page = document.Pages.Add();
    PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 12f);
    //Create a text box.
    PdfTextBoxField firstNameTextBox = new PdfTextBoxField(page, "firstNameTextBox");
    firstNameTextBox.MaxLength = 8;
    firstNameTextBox.Bounds = new RectangleF(100, 20, 200, 20);
    firstNameTextBox.Font = font;
    firstNameTextBox.Text = "Text Box";
    //Set the visibility.
    firstNameTextBox.Visibility = PdfFormFieldVisibility.Visible;
    page.Graphics.DrawString("First Name", font, PdfBrushes.Black, 10, 24);
    //Add the textbox in document.
    document.Form.Fields.Add(firstNameTextBox);
    //Save the document.
    document.Save(Path.GetFullPath(@"Output/OutputF.pdf"));
}