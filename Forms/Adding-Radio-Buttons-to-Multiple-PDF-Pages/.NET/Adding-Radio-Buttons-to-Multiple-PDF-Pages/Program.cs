using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Drawing;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Loop through multiple pages
    for (int i = 1; i <= 5; i++)
    {
        // Add a new page to the PDF document
        PdfPage page = document.Pages.Add();
        // Draw header text
        page.Graphics.DrawString($"Radio Button Example - {i}",
            new PdfStandardFont(PdfFontFamily.Helvetica, 20),
            PdfBrushes.Black, new PointF(10, 30));
        // Create a Radio Button List Field
        PdfRadioButtonListField employeesRadioList = new PdfRadioButtonListField(page, $"employeesRadioList_{i}")
        {
            AllowUnisonSelection = false // Each button acts independently
        };
        // Add the radio button field to the form
        document.Form.Fields.Add(employeesRadioList);
        // Draw option labels
        page.Graphics.DrawString("Option 1", new PdfStandardFont(PdfFontFamily.Helvetica, 12),
            PdfBrushes.Black, new PointF(50, 70));
        page.Graphics.DrawString("Option 2", new PdfStandardFont(PdfFontFamily.Helvetica, 12),
            PdfBrushes.Black, new PointF(50, 100));
        // Create radio button items with positions
        PdfRadioButtonListItem radioButtonItem1 = new PdfRadioButtonListItem("Option1")
        {
            Bounds = new RectangleF(10, 70, 20, 20)
        };
        PdfRadioButtonListItem radioButtonItem2 = new PdfRadioButtonListItem("Option2")
        {
            Bounds = new RectangleF(10, 100, 20, 20)
        };
        // Add items to the radio button group
        employeesRadioList.Items.Add(radioButtonItem1);
        employeesRadioList.Items.Add(radioButtonItem2);
    }
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}