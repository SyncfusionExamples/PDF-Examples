using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_angle_measurement_annotation_to_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a new PDF document.
            PdfDocument document = new PdfDocument();

            //Creates a new page.
            PdfPage page = document.Pages.Add();

            //Set the points for angle measurement. 
            PointF[] points = new PointF[] { new PointF(100, 700), new PointF(150, 650), new PointF(100, 600) };

            //Creates the angel measurement annotation.
            PdfAngleMeasurementAnnotation angleMeasureAnnotation = new PdfAngleMeasurementAnnotation(points);

            //Set font to the angle measurement annotation.
            angleMeasureAnnotation.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Regular);

            //Assign color to the angle measurement annotation.
            angleMeasureAnnotation.Color = Color.Red;

            //Adds angle measurement annotation.
            page.Annotations.Add(angleMeasureAnnotation);

            //Saves the document to disk.
            document.Save("AngleMeasurementAnnotation.pdf");

            //Close the document. 
            document.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF viewer.
            Process.Start("AngleMeasurementAnnotation.pdf");
        }
    }
}
