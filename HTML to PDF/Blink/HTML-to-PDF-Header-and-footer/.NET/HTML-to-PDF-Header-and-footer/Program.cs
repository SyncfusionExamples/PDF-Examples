using Syncfusion.HtmlConverter;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

namespace HTML_to_PDF_Header_and_footer {
    internal class Program {
        static void Main(string[] args) {
            //Initialize HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
            //Create PDF page template element for header with bounds.
            PdfPageTemplateElement header = new PdfPageTemplateElement(new RectangleF(0, 0, blinkConverterSettings.PdfPageSize.Width, 50));
            //Create font and brush for header element.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 7);
            PdfBrush brush = new PdfSolidBrush(Color.Black);
            //Draw the header string in header template element. 
            header.Graphics.DrawString("This is header", font, brush, PointF.Empty);
            //Assign the header element to PdfHeader of Blink converter settings.
            blinkConverterSettings.PdfHeader = header;
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
            //Save the PDF document 
            document.Save(Path.GetFullPath(@"Output/Output.pdf"));
            //Close the document.
            document.Close(true);
        }
    }
}