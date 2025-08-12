using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

class Program
{
    static void Main(string[] args)
    {
        //Create a new document.
        PdfDocument document = new PdfDocument();

        //Add a section to the document.
        PdfSection section = document.Sections.Add();

        //Set the font for the page number.
        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

        //Create a section page number field.
        PdfSectionPageNumberField sectionPageNumber = new PdfSectionPageNumberField();

        //Set the page number style to LowerRoman (i, ii, iii, etc.).
        sectionPageNumber.NumberStyle = PdfNumberStyle.LowerRoman;
        sectionPageNumber.Font = font;

        //Add pages to the section and draw the page number field in the footer.
        for (int i = 0; i < 3; i++)
        {
            //Add a new page to the section.
            PdfPage page = section.Pages.Add();

            //Get the page's client size to calculate the footer position.
            SizeF pageSize = page.GetClientSize();

            //Define the position for the page number in the footer (bottom-right).
            PointF footerPosition = new PointF(pageSize.Width - 50, pageSize.Height - 20);

            //Draw the section page number at the calculated footer position.
            sectionPageNumber.Draw(page.Graphics, footerPosition);

            // You can add other content to the main body of the page here.
            // For example, let's draw text at the top, leaving space for the footer.
            page.Graphics.DrawString("This is the main content of a page with a footer.", font, PdfBrushes.Black, new PointF(10, 10));
        }

        //Create file stream.
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
        {
            //Save the PDF document to file stream.
            document.Save(outputFileStream);
        }

        //Close the document.
        document.Close(true);
    }
}