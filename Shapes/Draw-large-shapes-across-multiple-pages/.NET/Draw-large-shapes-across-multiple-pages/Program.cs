// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create Document.
PdfDocument document = new PdfDocument();

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);