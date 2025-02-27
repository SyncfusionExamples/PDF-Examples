using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Add a page to the document
    PdfPage page = document.Pages.Add();
    // Create a font to be used for the text box.
    PdfTrueTypeFont font = new PdfTrueTypeFont(Path.GetFullPath(@"../../../Data/arial.ttf"), 12);
    // Create a text box field with RTL text
    PdfTextBoxField textBox = new PdfTextBoxField(page, "rtlTextBox");

    // Set the default text (RTL text, Arabic example)
    textBox.Text = "مرحبا بكم في عالم البرمجة"; // "Welcome to the world of programming" in Arabic
    // Set the text direction to Right-to-Left
    textBox.TextAlignment = PdfTextAlignment.Right;

    textBox.Bounds = new RectangleF(10, 10, 150, 50);
    // Set the font for the text box field
    textBox.Font = font;
    // Add the text box field to the page
    document.Form.Fields.Add(textBox);

    //Set default appearance as false.
    document.Form.SetDefaultAppearance(false);

    //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        document.Save(outputFileStream);
    }
}
