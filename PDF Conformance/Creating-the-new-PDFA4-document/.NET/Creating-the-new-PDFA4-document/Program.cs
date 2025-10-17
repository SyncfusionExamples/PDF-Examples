using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new document with the PDF/A-4 standard. 
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A4);

//Add a page to the document. 
PdfPage page = document.Pages.Add();

//Create the PDF graphics for the page. 
PdfGraphics graphics = page.Graphics;

//Get stream from the font file.  
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/Arial.ttf"), FileMode.Open, FileAccess.Read);

//Load the TrueType font from the local file. 
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

//Draw the text.
graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
document.Close(true);