//Create a new PDf document

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Drawing;

PdfDocument document = new PdfDocument();

//Creates a new page and adds it as the last page of the document

PdfPage page = document.Pages.Add();

PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 12f);

//Create a combo box

PdfComboBoxField positionComboBox = new PdfComboBoxField(page, "positionComboBox");

positionComboBox.Editable = true;

positionComboBox.Bounds = new RectangleF(100, 115, 200, 20);

positionComboBox.Font = font;

positionComboBox.Editable = true;

//Add it to document

document.Form.Fields.Add(positionComboBox);

using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
document.Close(true);

