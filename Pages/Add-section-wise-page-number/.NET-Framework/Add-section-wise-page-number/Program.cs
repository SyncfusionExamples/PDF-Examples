using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using System.Xml.Linq;
using System.Drawing;
using System.IO;

namespace Add_section_wise_page_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the PDF document
            PdfDocument document = new PdfDocument();

            // Initializing Font
            Font font = new System.Drawing.Font("Times new roman", 36, FontStyle.Regular);
            PdfFont trueTypeFont = new PdfTrueTypeFont(font, true);

            // Create Section 1 (First Section: No Page Numbers)
            PdfSection section1 = document.Sections.Add();
            section1.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle0;
            section1.PageSettings.Size = PdfPageSize.A4;
            // Add more pages to Section 1
            for (int i = 1; i <= 3; i++)
            {
                PdfPage page = section1.Pages.Add();
                page.Graphics.DrawString($"Section 1 - Page {i}", trueTypeFont, PdfPens.Black, PdfBrushes.Black, new PointF(10, 10));
            }

            // Create Section 2 (Second Section: With Footer and Page Numbers)
            PdfSection section2 = document.Sections.Add();
            section2.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;
            section2.PageSettings.Size = PdfPageSize.A4;
            // Add pages to Section 2 with page numbers
            for (int i = 1; i <= 3; i++)
            {
                PdfPage page = section2.Pages.Add();
                page.Graphics.DrawString($"Section 2 - Page {i}", trueTypeFont, PdfPens.Black, PdfBrushes.Black, new PointF(10, 10));
            }

            // Add footer with page numbers to Section 2
            AddFooter(section2, "@Copyright 2025");

            // Create Section 3 (Third Section: With Footer and Page Numbers)
            PdfSection section3 = document.Sections.Add();
            section3.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle180;
            section3.PageSettings.Size = PdfPageSize.A3;

            // Add pages to Section 3 with page numbers
            for (int i = 1; i <= 3; i++)
            {
                PdfPage page = section3.Pages.Add();
                page.Graphics.DrawString($"Section 3 - Page {i}", trueTypeFont, PdfPens.Black, PdfBrushes.Black, new PointF(10, 10));
            }

            // Add footer with page numbers to Section 3
            AddFooter(section3, "@Copyright 2025");

            //Create file stream.
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            document.Close(true);
        }

        #region Helper Methods
        /// <summary>
        /// Add footer to the PDF document with page number and page count.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="footerText"></param>
        private static void AddFooter(PdfSection section, string footerText)
        {
            // Create bounds for the footer
            RectangleF rect = new RectangleF(0, 0, section.Pages[0].GetClientSize().Width, 50);
            // Create a page template that can be used as footer
            PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);

            // Set font and brush for footer
            PdfSolidBrush brush = new PdfSolidBrush(Color.Gray);
            PdfPen pen = new PdfPen(Color.DarkBlue, 3f);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);

            // Set the string format for line alignment
            PdfStringFormat format = new PdfStringFormat
            {
                Alignment = PdfTextAlignment.Center,
                LineAlignment = PdfVerticalAlignment.Middle
            };

            // Draw footer text in PDF page
            footer.Graphics.DrawString(footerText, font, brush, new RectangleF(0, 18, footer.Width, footer.Height), format);

            format = new PdfStringFormat
            {
                Alignment = PdfTextAlignment.Right,
                LineAlignment = PdfVerticalAlignment.Bottom
            };

            // Create page number field
            PdfSectionPageNumberField pageNumber = new PdfSectionPageNumberField(font, brush);

            // Create page count field
            PdfSectionPageCountField count = new PdfSectionPageCountField(font, brush);

            // Add the fields in composite fields
            PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);
            compositeField.Bounds = footer.Bounds;

            // Draw the composite field in footer
            compositeField.Draw(footer.Graphics, new PointF(470, 40));

            // Add the footer template at the bottom
            section.Template.Bottom = footer;
        }
        #endregion
    }
}
