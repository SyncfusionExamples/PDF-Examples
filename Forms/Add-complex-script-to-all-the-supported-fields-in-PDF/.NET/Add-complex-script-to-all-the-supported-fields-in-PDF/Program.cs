// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a new PDF page.
PdfPage page = document.Pages.Add();

//Create the new PDF text box field.
PdfTextBoxField textField = new PdfTextBoxField(page, "textBox");

//Set bounds.
textField.Bounds = new RectangleF(10, 10, 200, 30);

//Set text.
textField.Text = "สวัสดีชาวโลก";

//Get stream from an font file.
FileStream fontStream = new FileStream(Path.GetFullPath("../../../tahoma.ttf"), FileMode.Open, FileAccess.Read);

//Create a new PDF font instance.
PdfFont font = new PdfTrueTypeFont(fontStream, 10);

//Set font.
textField.Font = font;

//Add the text box field to the form collection.
document.Form.Fields.Add(textField);

//Set default appearance as false.
document.Form.SetDefaultAppearance(false);

//Enable complex script layout for form.
document.Form.ComplexScript = true;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);