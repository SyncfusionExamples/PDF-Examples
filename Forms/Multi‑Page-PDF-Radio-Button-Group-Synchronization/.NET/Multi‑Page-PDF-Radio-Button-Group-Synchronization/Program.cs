using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Add pages (adjust count as needed)
    PdfPage[] pages = { document.Pages.Add(), document.Pages.Add() };
    // Access the document form
    PdfForm form = document.Form;
    // Disable auto field naming (we will name fields explicitly)
    form.FieldAutoNaming = false;
    // Common font for labels
    PdfFont labelFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Regular);
    // Shared settings
    string groupName = "EmployeesRadioGroup";                  // same group name across pages
    string[] exportValues = { "rb1", "rb2", "rb3" };           // consistent export values
    float[] startYs = { 200f, 300f };                          // starting Y per page
    float labelOffsetX = 10f;                                  // label X offset from radio button
    float labelOffsetY = -2f;                                  // label Y tweak
    for (int p = 0; p < pages.Length; p++)
    {
        PdfPage page = pages[p];
        // Create a radio button field for this page (same group name)
        PdfRadioButtonListField radioField = new PdfRadioButtonListField(page, groupName)
        {
            // Keep selection behavior consistent
            AllowUnisonSelection = true
        };
        // Add items and draw labels via loop
        for (int i = 0; i < exportValues.Length; i++)
        {
            // Intialized bounds value
            RectangleF bounds = new RectangleF(100f, startYs[p] + (i * 40f), 20f, 20f);
            // Create item with consistent export value
            PdfRadioButtonListItem item = new PdfRadioButtonListItem(page, exportValues[i])
            {
                Bounds = bounds
            };
            radioField.Items.Add(item);
            // Draw label near the radio button
            page.Graphics.DrawString($"Radio Button {i + 1}", labelFont, PdfBrushes.Black, bounds.Right + labelOffsetX, bounds.Y + labelOffsetY);
        }
        // Set default selection on the first page
        if (p == 0 && exportValues.Length > 0)
        {
            radioField.SelectedValue = exportValues[0];
        }
        // Add the field to the form
        form.Fields.Add(radioField);
    }
    // Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}