// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create Document.
PdfDocument document = new PdfDocument();

//Add new page.
PdfPage page = document.Pages.Add();

//Load a bitmap.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../Autumn Leaves.jpg"), FileMode.Open, FileAccess.Read);
PdfBitmap image = new PdfBitmap(imageStream);

//Set layout property to make the element break across the pages.
PdfLayoutFormat format = new PdfLayoutFormat();
format.Break = PdfLayoutBreakType.FitPage;
format.Layout = PdfLayoutType.Paginate;

//Draw image.
image.Draw(page, 20, 400, format);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream
    document.Save(outputFileStream);
}

//Close the document
document.Close(true);

