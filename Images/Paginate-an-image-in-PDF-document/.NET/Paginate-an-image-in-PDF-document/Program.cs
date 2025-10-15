using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add new page.
    PdfPage page = document.Pages.Add();

    //Load a bitmap.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Autumn Leaves.jpg"), FileMode.Open, FileAccess.Read);
    PdfBitmap image = new PdfBitmap(imageStream);

    //Set layout property to make the element break across the pages.
    PdfLayoutFormat format = new PdfLayoutFormat();
    format.Break = PdfLayoutBreakType.FitPage;
    format.Layout = PdfLayoutType.Paginate;

    //Draw image.
    image.Draw(page, 20, 400, format);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

