using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigate_to_external_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the PDF document.
            PdfDocument document = new PdfDocument();

            //Creates a new page.
            PdfPage page = document.Pages.Add();

            //Create a new rectangle.
            RectangleF bounds = new RectangleF(10, 40, 30, 30);

            //Create a link for image file.
            PdfFileLinkAnnotation fileLinkAnnotation = new PdfFileLinkAnnotation(bounds, Path.GetFullPath("../../Data/logo.png"));

            //Add this annotation to a page.
            page.Annotations.Add(fileLinkAnnotation);

            //Save the document to disk.
            document.Save("FileLinkAnnotation.pdf");

            //close the document
            document.Close();

            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("FileLinkAnnotation.pdf");
        }
    }
}
