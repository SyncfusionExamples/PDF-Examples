using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;


// Create a new PDF document
PdfDocument document = new PdfDocument();
// Add a new page to the PDF document
PdfPage page = document.Pages.Add();

// Create a new radio button list field named "employeesRadioList"
PdfRadioButtonListField employeesRadioList = new PdfRadioButtonListField(page, "employeesRadioList");
// Create a font
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Regular);

// Create a new radio button item for "Male"
PdfRadioButtonListItem radioItem1 = new PdfRadioButtonListItem("Male");
// Set the bounds for the radio button
radioItem1.Bounds = new RectangleF(90, 203, 15, 15);
// Draw the label "Male"
page.Graphics.DrawString("Male", font, PdfBrushes.Black, new RectangleF(110, 204, 180, 20));
// Add the radio button item to the list
employeesRadioList.Items.Add(radioItem1);

// Create a new radio button item for "Female"
PdfRadioButtonListItem radioItem2 = new PdfRadioButtonListItem("Female");
// Set the bounds for the radio button
radioItem2.Bounds = new RectangleF(205, 203, 15, 15);
// Draw the label "Female"
page.Graphics.DrawString("Female", font, PdfBrushes.Black, new RectangleF(225, 204, 180, 20));
// Add the radio button item to the list
employeesRadioList.Items.Add(radioItem2);

employeesRadioList.SelectedIndex = 1;
// Add the radio button list to the form
document.Form.Fields.Add(employeesRadioList);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

