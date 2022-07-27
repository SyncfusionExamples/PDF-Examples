// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Create a solid brush and standard font.
PdfBrush brush = new PdfSolidBrush(Color.Black);
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

//Section - 1
//Add new section to the document.
PdfSection section = document.Sections.Add();

//Create page settings to the section.
section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle0;
section.PageSettings.Size = PdfPageSize.A5;
section.PageSettings.Width = 300;
section.PageSettings.Height = 400;

//Add page to the section and initialize graphics for the page.
PdfPage page = section.Pages.Add();
PdfGraphics graphics = page.Graphics;

//Draw simple text on the page.
graphics.DrawString("Rotated by 0 degrees", font, brush, new PointF(20, 20));

//Section - 2
//Add new section to the document.
section = document.Sections.Add();

//Create page settings to the section.
section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;
section.PageSettings.Width = 300;
section.PageSettings.Height = 400;

//Add page to the section and initialize graphics for the page.
page = section.Pages.Add();
graphics = page.Graphics;

//Draw simple text on the page.
graphics.DrawString("Rotated by 90 degrees", font, brush, new PointF(20, 20));

//Section - 3
//Add new section to the document.
section = document.Sections.Add();

//Create page settings to the section.
section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle180;
section.PageSettings.Width = 500;
section.PageSettings.Height = 200;

//Add page to the section and initialize graphics for the page.
page = section.Pages.Add();
graphics = page.Graphics;

//Draw simple text on the page.
graphics.DrawString("Rotated by 180 degrees", font, brush, new PointF(20, 20));

//Section - 4
//Add new section to the document.
section = document.Sections.Add();

//Create page settings to the section.
section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle270;
section.PageSettings.Width = 300;
section.PageSettings.Height = 200;

//Add page to the section and initialize graphics for the page.
page = section.Pages.Add();
graphics = page.Graphics;

//Draw simple text on the page.
graphics.DrawString("Rotated by 270 degrees", font, brush, new PointF(20, 20));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

