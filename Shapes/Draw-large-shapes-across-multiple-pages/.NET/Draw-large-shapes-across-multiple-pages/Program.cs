using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add new page.
    PdfPage page = document.Pages.Add();

    //Set bounds for ellipse.
    RectangleF rect = new RectangleF(0, 0, 100, 1000);

    //Create ellipse.
    PdfEllipse ellipse = new PdfEllipse(rect);

    //Set layout property to make the ellipse break across the pages.
    PdfLayoutFormat format = new PdfLayoutFormat();
    format.Break = PdfLayoutBreakType.FitPage;
    format.Layout = PdfLayoutType.Paginate;
    ellipse.Brush = PdfBrushes.Brown;

    //Draw ellipse.
    ellipse.Draw(page, 20, 20, format);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}