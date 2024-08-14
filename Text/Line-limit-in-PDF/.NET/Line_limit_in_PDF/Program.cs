using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

// Create a new PdfStringFormat and set its properties
PdfStringFormat format = new PdfStringFormat();
//Set no clip
format.NoClip = true;
//Set line limit
format.LineLimit = false;

// Create a new PdfFont using the Helvetica font family
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

// Create a new PdfDocument
PdfDocument document = new PdfDocument();
// Set the page margins to zero
document.PageSettings.Margins.All = 0;

// Add a new page to the document
PdfPage page = document.Pages.Add();

// Get the graphics object of the page
PdfGraphics graphics = page.Graphics;

// Draw a red rectangle at the specified position and size
graphics.DrawRectangle(PdfPens.Red, new RectangleF(100, 100, 100, 20));

// Draw the string inside the rectangle with the specified font, brush, and format
graphics.DrawString("PDF text line 1 \r\nPDF text line 3", font, PdfBrushes.Black, new RectangleF(100, 100, 100, 20), format);

// Create a memory stream to save the PDF document
MemoryStream stream = new MemoryStream();
// Save the document to the memory stream
document.Save(stream);
// Write the content of the memory stream to a file named "output.pdf"
File.WriteAllBytes(Path.GetFullPath(@"Output/Output.pdf"), stream.ToArray());
// Close the document and release all resources
document.Close(true);