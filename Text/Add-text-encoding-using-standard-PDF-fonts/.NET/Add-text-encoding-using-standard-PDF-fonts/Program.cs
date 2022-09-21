// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Text;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Adding a new page to the PDF document 
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Create a new PDF standard font instance.
PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

//Set the text encoding.
font.SetTextEncoding(Encoding.GetEncoding("Windows-1250"));

//Draw string to a PDF page.
graphics.DrawString("äÖíßĆŇ", font, PdfBrushes.Black, PointF.Empty);

//Create file stream.z              
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

