using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

// Create a new PDF document
PdfDocument document = new PdfDocument();
// Add a new PDF page
PdfPage page = document.Pages.Add();
//Create font
PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 12f);
//Draw the label text
page.Graphics.DrawString("First Name", font, PdfBrushes.Black, 10, 55);
//Create a text box
PdfTextBoxField firstNameTextBox = new PdfTextBoxField(page, "FirstNameTextBox");
//Set bounds of the text box.
firstNameTextBox.Bounds = new RectangleF(100, 20, 200, 20);
//Set font
firstNameTextBox.Font = font;
//Set the text box default text
firstNameTextBox.Text = "John";
//Set the text box field visibility.
firstNameTextBox.Visibility = PdfFormFieldVisibility.Visible;
//Add the textbox to the document
document.Form.Fields.Add(firstNameTextBox);
//Save the document.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    document.Save(outputFileStream);
}
//Close the document
document.Close(true);