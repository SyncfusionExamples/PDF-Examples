using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

namespace Create_PDF {
    internal class Program {
        static void Main(string[] args) {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            //Draw the text.
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
            //Create a fileStream.
            FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.CreateNew, FileAccess.ReadWrite);
            //Save and close the PDF document.
            document.Save(fileStream);
            document.Close(true);

        }
    }
}