using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Text;

//Create a PDF document instance.
PdfDocument document = new PdfDocument();

//Add the event.
document.Pages.PageAdded += Pages_PageAdded;

//Create a new page and add it as the last page of the document.
PdfPage page = document.Pages.Add();

//Create graphics for the page.
PdfGraphics graphics = page.Graphics;

//Read the long text from the text file.
FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.txt"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
StreamReader reader = new StreamReader(inputStream, Encoding.ASCII);
string text = reader.ReadToEnd();
reader.Dispose();

//Set the paragraph gap. 
const int paragraphGap = 10;

//Create a text element with the text and font.
PdfTextElement textElement = new PdfTextElement(text, new PdfStandardFont(PdfFontFamily.TimesRoman, 14));
PdfLayoutFormat layoutFormat = new PdfLayoutFormat();
layoutFormat.Layout = PdfLayoutType.Paginate;
layoutFormat.Break = PdfLayoutBreakType.FitPage;

//Draw the first paragraph.
PdfLayoutResult result = textElement.Draw(page, new RectangleF(0, 0, page.GetClientSize().Width / 2, page.GetClientSize().Height), layoutFormat);

//Draw the second paragraph from the first paragraph’s end position.
result = textElement.Draw(result.Page, new RectangleF(0, result.Bounds.Bottom + paragraphGap, page.GetClientSize().Width / 2, page.GetClientSize().Height), layoutFormat);

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
document.Close(true);

void Pages_PageAdded(object sender, PageAddedEventArgs args)
{
    PdfPage page = args.Page;
    page.Graphics.DrawRectangle(PdfPens.Black, new RectangleF(0, 0, page.GetClientSize().Width, page.GetClientSize().Height));
}
