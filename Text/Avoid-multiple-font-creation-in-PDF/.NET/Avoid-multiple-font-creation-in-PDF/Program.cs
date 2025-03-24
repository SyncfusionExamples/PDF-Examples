using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

// Create a new PDF document
PdfDocument document = new PdfDocument();

// Open the font stream once to use it for all pages instead of opening it repeatedly in each iteration
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/Arial.ttf"), FileMode.Open, FileAccess.Read);

// Load the font from the font stream with a size of 14
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

// Add 10 pages to the PDF document
for (int i = 0; i < 10; i++)
{
    // Add a new page to the document
    PdfPage page = document.Pages.Add();

    // Create PDF graphics for the page
    PdfGraphics graphics = page.Graphics;

    // Create a solid black brush to draw text on the page
    PdfBrush brush = new PdfSolidBrush(Color.Black);

    // Draw the text on the page at coordinates (20, 20), appending the iteration number (i) to each string
    graphics.DrawString("Hello world!-" + i, font, brush, new PointF(20, 20));
}

// Create a file stream to save the PDF document to a file in the specified output path
using (FileStream stream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
{ 
    // Save the PDF document to the file stream
    document.Save(stream);
}

// Close the document and release resources
document.Close(true);

// Dispose of the font stream to free up resources
fontStream.Dispose();
