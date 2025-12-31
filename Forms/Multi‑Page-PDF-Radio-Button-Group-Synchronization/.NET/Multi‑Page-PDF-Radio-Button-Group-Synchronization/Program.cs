using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Create two pages
    PdfPage page1 = document.Pages.Add();
    PdfPage page2 = document.Pages.Add();
    // Access the form
    PdfForm form = document.Form;
    form.FieldAutoNaming = false;
    // Label font
    PdfFont labelFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Regular);
    // Group name
    string groupName = "EmployeesRadioGroup";
    float labelOffsetX = 10f;
    float labelOffsetY = -2f;
    // Create ONE radio button list field (anchor it on the first page; items can be on any page)
    PdfRadioButtonListField radioField = new PdfRadioButtonListField(page1, groupName)
    {
        // Keep standard radio behavior: only one selection in the group
        AllowUnisonSelection = false
    };
    // Define the 4 radio items: 2 on page 1, 2 on page 2
    var items = new (PdfPage page, string export, RectangleF bounds, string label)[]
    {
                    (page1, "rb1", new RectangleF(100f, 200f, 20f, 20f), "Radio Button 1"),
                    (page1, "rb2", new RectangleF(100f, 240f, 20f, 20f), "Radio Button 2"),
                    (page2, "rb3", new RectangleF(100f, 200f, 20f, 20f), "Radio Button 3"),
                    (page2, "rb4", new RectangleF(100f, 240f, 20f, 20f), "Radio Button 4"),
    };
    // Add items to the single radio field and draw their labels
    foreach (var (page, export, bounds, label) in items)
    {
        PdfRadioButtonListItem item = new PdfRadioButtonListItem(page, export)
        {
            Bounds = bounds
        };
        radioField.Items.Add(item);
        // Label beside the radio button
        page.Graphics.DrawString(label, labelFont, PdfBrushes.Black,
            bounds.Right + labelOffsetX, bounds.Y + labelOffsetY);
    }
    // Set default selection
    radioField.SelectedValue = "rb4";
    // Add the single field to the form
    form.Fields.Add(radioField);
    // Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}