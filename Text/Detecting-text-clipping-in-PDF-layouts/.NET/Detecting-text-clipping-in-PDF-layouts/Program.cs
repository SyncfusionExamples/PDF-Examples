using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

// Create a new PDF document
PdfDocument document = new PdfDocument();

// Add a page to the document
PdfPage page = document.Pages.Add();

// Create PDF graphics for the page
PdfGraphics graphics = page.Graphics;

// Set the standard font
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 30);

// Declare the text to be drawn
string text = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";

// Define the bounds within which the text should be drawn
RectangleF border = new RectangleF(0, 0, page.GetClientSize().Width, 150);

// Draw a rectangle to visualize the layout bounds
graphics.DrawRectangle(PdfPens.Black, border);

// Initialize the PdfStringLayouter to layout the text
PdfStringLayouter layouter = new PdfStringLayouter();

// Layout the text and get the result to check if it fits within the bounds
PdfStringLayoutResult result = layouter.Layout(text, font, new PdfStringFormat(PdfTextAlignment.Center), new SizeF(border.Width, border.Height));

// Check if any part of the text was clipped (did not fit within the specified bounds)
if (result.Remainder != null)
{
    // Store the clipped portion of the text for further processing or logging
    string remainderText = result.Remainder;
    // Output the clipped text to the console for debugging or review
    Console.WriteLine("Remainder Text: " + remainderText);
}
// Close the document and release resources
document.Close(true);

