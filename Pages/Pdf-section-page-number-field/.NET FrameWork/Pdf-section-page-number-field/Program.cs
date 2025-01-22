using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_footer_sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create the PDF document
            PdfDocument document = new PdfDocument();

            //Initializing Font
            Font font = new Font("Times new roman", 36, FontStyle.Regular);
            PdfFont trueTypeFont = new PdfTrueTypeFont(font, true);

            PdfPage page = document.Pages.Add();
            //Drawing some text at first page. 
            page.Graphics.DrawString("Hello World!!!", trueTypeFont, PdfPens.Black, PdfBrushes.Black, new PointF(10, 10));

            //Adding new section for 1st page alone where the page number not to be added.
            PdfSection section1 = document.Sections.Add();
            PdfPage sectionPage= section1.Pages.Add();
            //Adding 3 pages with content in section2.
            for (int i = 2; i <= 4; i++)
            {
                //Adding a new page to PDF document.
                sectionPage = section1.Pages.Add();

                //Drawing some text at new page.
                sectionPage.Graphics.DrawString("Hello World!!!", trueTypeFont, PdfPens.Black, PdfBrushes.Black, new PointF(10, 10));
            }
            //Adding footer only to 2nd section.
            AddFooter(section1, "@Copyright 2007");

            //Save the document.
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }

            //Close the document.
            document.Close(true);
        }

        #region Helper Methods
        /// <summary>
        /// Add footer to the PDF document.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="footerText"></param>
        private static void AddFooter(PdfSection section, string footerText)
        {
            //Create bounds for the footer. 
            RectangleF rect = new RectangleF(0, 0, section.Pages[0].GetClientSize().Width, 50);

            //Create a page template that can be used as footer. 
            PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);

            //Set font and brush. 
            PdfSolidBrush brush = new PdfSolidBrush(Color.Gray);
            PdfPen pen = new PdfPen(Color.DarkBlue, 3f);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);           
            
            //Set the string format for line alignment. 
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            
            //Draw footer text in PDF page.
            footer.Graphics.DrawString(footerText, font, brush, new RectangleF(0, 18, footer.Width, footer.Height), format);
            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Right;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Create page number field.
            PdfSectionPageNumberField pageNumber = new PdfSectionPageNumberField(font, brush);

            //Create page count field.
            PdfSectionPageCountField count = new PdfSectionPageCountField(font, brush);
            //Add the fields in composite fields.
            PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);
            compositeField.Bounds = footer.Bounds;
            //Draw the composite field in footer.
            compositeField.Draw(footer.Graphics, new PointF(470, 40));

            //Add the footer template at the bottom
            section.Template.Bottom = footer;

        }
        #endregion
    }
}
