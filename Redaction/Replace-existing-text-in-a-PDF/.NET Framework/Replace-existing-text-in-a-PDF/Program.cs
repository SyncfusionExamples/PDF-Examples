using System.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using System.Collections.Generic;
using System.IO;

namespace Replace_existing_text_in_a_PDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load the PDF document
            using (PdfLoadedDocument ldoc = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
            {
                // Dictionary to store the found text bounds for each page
                Dictionary<int, List<RectangleF>> matchedTextbounds = new Dictionary<int, List<RectangleF>>();
                // Get the first page of the PDF
                PdfLoadedPage page = ldoc.Pages[0] as PdfLoadedPage;
                // Search for the text and get its bounding rectangles
                ldoc.FindText("Fusce", out matchedTextbounds);
                // Loop through each page with matches
                for (int i = 0; i < matchedTextbounds.Count; i++)
                {
                    // Get all rectangles where the text was found on this page
                    List<RectangleF> rectangles = matchedTextbounds[i];
                    // Loop through each found rectangle
                    for (int j = 0; j < rectangles.Count; j++)
                    {
                        // Create a redaction area with transparent fill over the found text
                        PdfRedaction redaction = new PdfRedaction(rectangles[j], Color.Transparent);
                        // Draw the replacement text on the redaction area
                        redaction.Appearance.Graphics.DrawString(
                            "Hello",
                            new PdfStandardFont(PdfFontFamily.Helvetica, 9),
                            PdfBrushes.Black,
                            PointF.Empty
                        );
                        // Add the redaction to the page
                        page.AddRedaction(redaction);
                    }
                }
                // Save the PDF document
                ldoc.Save(Path.GetFullPath(@"Output/Output.pdf"));
            }
        }
    }
}
