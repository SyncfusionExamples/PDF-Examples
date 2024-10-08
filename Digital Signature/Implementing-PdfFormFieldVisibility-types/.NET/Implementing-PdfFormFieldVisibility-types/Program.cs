using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

PdfDocument document = new PdfDocument();
//Creates a new page and adds it as the last page of the document
PdfPage page = document.Pages.Add();
PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 12f);
//Create a text box
PdfTextBoxField firstNameTextBox = new PdfTextBoxField(page, "firstNameTextBox");
firstNameTextBox.MaxLength = 8;
firstNameTextBox.Bounds = new RectangleF(100, 20, 200, 20);
firstNameTextBox.Font = font;
firstNameTextBox.Text = "Text Box";
//Set the visibility.
firstNameTextBox.Visibility = PdfFormFieldVisibility.Visible;
page.Graphics.DrawString("First Name", font, PdfBrushes.Black, 10, 55);
//Add the textbox in document
document.Form.Fields.Add(firstNameTextBox);
//Save the document.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    document.Save(outputFileStream);
}
//Close the document
document.Close(true);