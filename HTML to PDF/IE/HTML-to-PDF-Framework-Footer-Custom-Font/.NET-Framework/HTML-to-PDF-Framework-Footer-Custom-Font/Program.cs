using System.Drawing;
using System.IO;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace HTML_to_PDF_Framework_Footer_Custom_Font
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
            //Create font and brush for footer element.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8);
            PdfBrush brush = new PdfSolidBrush(Color.Black);
            //Create PDF page template element for footer with bounds.
            PdfPageTemplateElement footer = new PdfPageTemplateElement(new RectangleF(0, 0, blinkConverterSettings.PdfPageSize.Width, 50));
            //Create page number field.
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, PdfBrushes.Black);
            //Create page count field.
            PdfPageCountField count = new PdfPageCountField(font, PdfBrushes.Black);
            //Add the fields in composite fields.
            PdfCompositeField compositeField = new PdfCompositeField(font, PdfBrushes.Black, "Page {0} of {1}", pageNumber, count);
            //Draw the composite field in footer
            compositeField.Draw(footer.Graphics, PointF.Empty);
            //Assign the footer element to PdfFooter of Blink converter settings.
            blinkConverterSettings.PdfFooter = footer;
            //Set Blink viewport size.
            blinkConverterSettings.ViewPortSize = new Size(1024, 0);
            htmlConverter.ConverterSettings = blinkConverterSettings;
            //Convert URL to PDF.
            PdfDocument document = htmlConverter.Convert("https://www.google.com/");
            //Save a PDF document to the file stream.
            document.Save("Output.pdf");
            //Close the document.
            document.Close(true);
        }
    }
}
