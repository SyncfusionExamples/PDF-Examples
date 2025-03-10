using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document
PdfDocument document = new PdfDocument();
for (int i = 1; i <= 5; i++)
{
    //Add a new page to PDF document
    PdfPage page = document.Pages.Add();
    //Draw string
    page.Graphics.DrawString("Radio Button Example-" + i, new PdfStandardFont(PdfFontFamily.Helvetica, 20), PdfBrushes.Black, new PointF(10, 30));
    //Create a Radio button
    PdfRadioButtonListField employeesRadioList = new PdfRadioButtonListField(page, "employeesRadioList");
    //Add the radio button into form
    document.Form.Fields.Add(employeesRadioList);
    page.Graphics.DrawString("Option1", new PdfStandardFont(PdfFontFamily.Helvetica, 12), PdfBrushes.Black, new PointF(50, 70));
    //Create radio button items
    PdfRadioButtonListItem radioButtonItem1 = new PdfRadioButtonListItem("Option1");
    radioButtonItem1.Bounds = new RectangleF(10, 70, 20, 20);
    page.Graphics.DrawString("Option2", new PdfStandardFont(PdfFontFamily.Helvetica, 12), PdfBrushes.Black, new PointF(50, 100));
    PdfRadioButtonListItem radioButtonItem2 = new PdfRadioButtonListItem("Option2");
    radioButtonItem2.Bounds = new RectangleF(10, 100, 20, 20);
    //Add the items to radio button group
    employeesRadioList.Items.Add(radioButtonItem1);
    employeesRadioList.Items.Add(radioButtonItem2);
}
// Save the PDF document to a file
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    document.Save(outputFileStream);
}
//Close the document
document.Close(true);