using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customizing_the_RTF_to_PDF_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loads an existing Word document.
            WordDocument rtfDocument = new WordDocument("../../Data/Essential PDF.rtf");

            //Create an instance of DocToPDFConverter - responsible for Word to PDF conversion.
            DocToPDFConverter converter = new DocToPDFConverter();

            //Set the image quality.
            converter.Settings.ImageQuality = 100;

            //Set the image resolution.
            converter.Settings.ImageResolution = 640;

            //Set true to optimize the memory usage for identical images.
            converter.Settings.OptimizeIdenticalImages = true;

            //Convert Word document into PDF document.
            PdfDocument pdfDocument = converter.ConvertToPDF(rtfDocument);

            //Save the PDF file to file system.
            pdfDocument.Save("RTFToPDF.pdf");

            //Close the instance of document objects.
            pdfDocument.Close(true);
            rtfDocument.Close();

            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("RTFToPDF.pdf");
        }
    }
}
