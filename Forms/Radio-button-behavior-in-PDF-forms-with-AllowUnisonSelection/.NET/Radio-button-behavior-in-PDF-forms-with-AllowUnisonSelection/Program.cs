using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a PDF document
using (PdfDocument document = new PdfDocument())
{
    //Page 1 - AllowUnisonSelection DISABLED(Independent behavior)
    PdfPage page1 = document.Pages.Add();
    page1.Graphics.DrawString("Independent Radio Buttons",
        new PdfStandardFont(PdfFontFamily.Helvetica, 16),
        PdfBrushes.Black, new PointF(10, 20));

    PdfRadioButtonListField independentGroup = new PdfRadioButtonListField(page1, "IndependentGroup")
    {
        // Each button acts independently
        AllowUnisonSelection = false
    };
    PdfRadioButtonListItem item1 = new PdfRadioButtonListItem("OptionA")
    {
        Bounds = new RectangleF(10, 60, 20, 20)
    };
    // Same label but independent
    PdfRadioButtonListItem item2 = new PdfRadioButtonListItem("OptionA")
    {
        Bounds = new RectangleF(10, 100, 20, 20)
    };
    independentGroup.Items.Add(item1);
    independentGroup.Items.Add(item2);
    document.Form.Fields.Add(independentGroup);
    page1.Graphics.DrawString("Option A (1)", new PdfStandardFont(PdfFontFamily.Helvetica, 12),
        PdfBrushes.Black, new PointF(40, 60));
    page1.Graphics.DrawString("Option A (2)", new PdfStandardFont(PdfFontFamily.Helvetica, 12),
        PdfBrushes.Black, new PointF(40, 100));
    //Page 2 - AllowUnisonSelection ENABLED(Unified behavior)
    PdfPage page2 = document.Pages.Add();
    page2.Graphics.DrawString("Unified Radio Buttons",
        new PdfStandardFont(PdfFontFamily.Helvetica, 16),
        PdfBrushes.Black, new PointF(10, 20));
    PdfRadioButtonListField unifiedGroup = new PdfRadioButtonListField(page2, "UnifiedGroup")
    {
        // Buttons share selection state
        AllowUnisonSelection = true
    };
    PdfRadioButtonListItem item3 = new PdfRadioButtonListItem("OptionB")
    {
        Bounds = new RectangleF(10, 60, 20, 20)
    };
    // Same label, unified selection
    PdfRadioButtonListItem item4 = new PdfRadioButtonListItem("OptionB")
    {
        Bounds = new RectangleF(10, 100, 20, 20)
    };
    unifiedGroup.Items.Add(item3);
    unifiedGroup.Items.Add(item4);
    document.Form.Fields.Add(unifiedGroup);
    page2.Graphics.DrawString("Option B (1)", new PdfStandardFont(PdfFontFamily.Helvetica, 12),
        PdfBrushes.Black, new PointF(40, 60));
    page2.Graphics.DrawString("Option B (2)", new PdfStandardFont(PdfFontFamily.Helvetica, 12),
        PdfBrushes.Black, new PointF(40, 100));
    //Save the document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}