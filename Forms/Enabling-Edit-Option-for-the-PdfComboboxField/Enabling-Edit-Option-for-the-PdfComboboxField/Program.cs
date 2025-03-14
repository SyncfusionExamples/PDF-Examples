//Create a new PDF document
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

PdfDocument document = new PdfDocument();

//Add page
PdfPage page = document.Pages.Add();

//Create a PDF standard font
PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 12f);

//Create a combo box

PdfComboBoxField positionComboBox = new PdfComboBoxField(page, "positionComboBox");

//Set the combo box bounds
positionComboBox.Bounds = new RectangleF(100, 115, 200, 20);

//Set the font
positionComboBox.Font = font;

//Enable editing option
positionComboBox.Editable = true;

//Add it to document
document.Form.Fields.Add(positionComboBox);

using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
document.Close(true);