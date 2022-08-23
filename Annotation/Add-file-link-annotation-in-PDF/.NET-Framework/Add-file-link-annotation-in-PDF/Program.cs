using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_file_link_annotation_in_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a new PDF document
            PdfDocument document = new PdfDocument();

            //Creates a new page
            PdfPage page = document.Pages.Add();

            //Creates a new rectangle
            RectangleF rectangle = new RectangleF(10, 40, 30, 30);

            //Creates a new pdf file link annotation.
            PdfFileLinkAnnotation fileLinkAnnotation = new PdfFileLinkAnnotation(rectangle, @"../../Data/logo.png");

            //Adds this annotation to a new page.
            page.Annotations.Add(fileLinkAnnotation);

            //Saves the document to disk.
            document.Save("FileLinkAnnotation.pdf");

            //Close the document. 
            document.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("FileLinkAnnotation.pdf");
        }
    }
}
