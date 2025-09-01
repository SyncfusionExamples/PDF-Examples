using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Convert_EMF_to_PDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new PDF document
            PdfDocument doc = new PdfDocument();

            // Set all page margins to zero
            doc.PageSettings.Margins.All = 0;

            // Add a new page to the document
            PdfPage page = doc.Pages.Add();

            // Create PDF graphics object for drawing on the page
            PdfGraphics graphics = page.Graphics;

            // Define layout format for rendering metafile content
            PdfMetafileLayoutFormat format = new PdfMetafileLayoutFormat();

            // Enable splitting of images across pages if needed
            format.SplitImages = true;

            // Enable splitting of text lines across pages if needed
            format.SplitTextLines = true;

            // Load the EMF (Enhanced Metafile) image from file
            Metafile metaChart = new Metafile(@"../../Data/Input.emf");

            // Convert the metafile to a PDF-compatible format
            PdfMetafile pdfMetaChart = new PdfMetafile(metaChart);

            // Draw the metafile image on the entire page area
            graphics.DrawImage(pdfMetaChart, new RectangleF(0, 0, page.GetClientSize().Width, page.GetClientSize().Height));

            // Save the document to a file
            doc.Save(@"Output.pdf");

            // Close the document and release resources
            doc.Close(true);
        }
    }
}
