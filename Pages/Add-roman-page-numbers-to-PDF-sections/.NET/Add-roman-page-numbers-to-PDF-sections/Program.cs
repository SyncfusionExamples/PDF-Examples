using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new document.
PdfDocument document = new PdfDocument();
//Add the section.
PdfSection section = document.Sections.Add();
//Set the font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
//Create section page number field.
PdfSectionPageNumberField sectionPageNumber = new PdfSectionPageNumberField();
sectionPageNumber.NumberStyle = PdfNumberStyle.LowerRoman;
sectionPageNumber.Font = font;
//Draw the sectionPageNumber in section.
for (int i = 0; i < 3; i++)
{
    PdfPage page = section.Pages.Add();
    sectionPageNumber.Draw(page.Graphics);
    page.Graphics.DrawString("This code is a practical example of how to automatically add Roman numeral page numbers", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, 0));
}
//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);