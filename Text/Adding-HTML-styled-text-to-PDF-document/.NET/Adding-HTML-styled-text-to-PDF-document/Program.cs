// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page to the document.
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Set the font.
PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14, PdfFontStyle.Regular);

//Simple HTML content.
string htmlText = "<font color='#0000F8' face='TimesRoman' size='14'><i><b><u>Essential PDF</u></b></i></font> is a <u><i>.NET</i></u> library with the capability to produce Adobe PDF files";

//Render Html text.
PdfHTMLTextElement richTextElement = new PdfHTMLTextElement(htmlText, font, PdfBrushes.Black);

//Format layout.
PdfLayoutFormat format = new PdfLayoutFormat();
format.Layout = PdfLayoutType.Paginate;
format.Break = PdfLayoutBreakType.FitPage;

//Draw htmlString.
richTextElement.Draw(page, new RectangleF(0, 20, page.GetClientSize().Width, page.GetClientSize().Height), format);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);