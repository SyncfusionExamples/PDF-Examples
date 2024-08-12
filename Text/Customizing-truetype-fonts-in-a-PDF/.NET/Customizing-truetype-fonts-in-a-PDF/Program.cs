
//Create a new PDF document.
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics.Fonts;

PdfDocument document = new PdfDocument();
//Add a page to the document.
PdfPage page = document.Pages.Add();
//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;
//Load the TrueType font from the local *.ttf file.
FileStream fontStream = new FileStream(@"Data/arial.ttf", FileMode.Open, FileAccess.Read);
// Initialize the PdfFontSettings
PdfFontSettings fontSettings = new PdfFontSettings(10, PdfFontStyle.Bold, true, true, true);
PdfFont pdfFont = new PdfTrueTypeFont(fontStream, fontSettings);
//Draw the text.
graphics.DrawString("Hello World!!!", pdfFont, PdfBrushes.Black, new PointF(0, 0));
//Save the document into stream.
MemoryStream stream = new MemoryStream();
document.Save(stream);
File.WriteAllBytes("Output/Output.pdf", stream.ToArray());
//Close the document.
document.Close(true);
