//Create a new PDF document 

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

PdfDocument document = new PdfDocument();

//Add a page to the document 

PdfPage page = document.Pages.Add();

// Load the font file from the stream 

FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/arial.ttf"), FileMode.Open, FileAccess.Read);

//Create a new PDF font instance 

PdfFont font = new PdfTrueTypeFont(fontStream, 14, PdfFontStyle.Italic);

//Create a new PDF string format instance 

PdfStringFormat format = new PdfStringFormat();

//Enable the measure tilting space      

format.MeasureTiltingSpace = true;

string text = "Hello World!";

//Measure the tilted text 

SizeF size = font.MeasureString(text, format);

//Draw the text to the PDF document. 

page.Graphics.DrawString(text, font, PdfBrushes.Black, new RectangleF(0, 0, size.Width, size.Height));

//Creating the stream object 

MemoryStream stream = new MemoryStream();

//Save the document as stream 

document.Save(stream);

File.WriteAllBytes(Path.GetFullPath(@"Output/Output.pdf"), stream.ToArray());
    
//Close the document 

document.Close(true);
