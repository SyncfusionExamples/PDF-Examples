//Create a new PDF document.
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

PdfDocument document = new PdfDocument();

//Create a solid brush and standard font.
PdfBrush brush = new PdfSolidBrush(Color.Black);
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

// Section – 1 
//Add new section to the document
PdfSection section = document.Sections.Add();
//Page-settings.
section.PageSettings.Margins.All = 0.5f;
section.PageSettings.Width = 300;
section.PageSettings.Height = 400;

//Add a page and draw text.
PdfPage page = section.Pages.Add();
PdfGraphics g = page.Graphics;
g.DrawString(
    "Essential PDF is a library with the capability to produce Adobe PDF files",
    font, brush,
    new RectangleF(0, 0, page.GetClientSize().Width - 20, page.GetClientSize().Height));

//Section – 2 
//Add new section to the document
section = document.Sections.Add();
section.PageSettings.Margins.All = 5f;
section.PageSettings.Width = 300;
section.PageSettings.Height = 400;

page = section.Pages.Add();
g = page.Graphics;
g.DrawString(
    "Essential PDF is a library with the capability to produce Adobe PDF files",
    font, brush,
    new RectangleF(0, 0, page.GetClientSize().Width - 20, page.GetClientSize().Height));

//Save and close the document.
document.Save(Path.GetFullPath(@"Output/Output.pdf")); 
document.Close(true);
