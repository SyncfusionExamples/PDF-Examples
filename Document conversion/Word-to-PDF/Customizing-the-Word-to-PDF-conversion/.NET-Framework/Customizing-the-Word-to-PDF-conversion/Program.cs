using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.OfficeChart;
using Syncfusion.OfficeChartToImageConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customizing_the_Word_to_PDF_conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loads an existing Word document.
            WordDocument wordDocument = new WordDocument("../../Data/Adventure.docx", FormatType.Docx);

            //Initialize chart to image converter for converting charts during Word to pdf conversion.
            wordDocument.ChartToImageConverter = new ChartToImageConverter();

            //Set the scaling mode for charts.
            wordDocument.ChartToImageConverter.ScalingMode = ScalingMode.Normal;

            //Create an instance of DocToPDFConverter - responsible for Word to PDF conversion.
            DocToPDFConverter converter = new DocToPDFConverter();

            //Set the image quality.
            converter.Settings.ImageQuality = 100;

            //Set the image resolution.
            converter.Settings.ImageResolution = 640;

            //Set true to optimize the memory usage for identical images.
            converter.Settings.OptimizeIdenticalImages = true;

            //Convert Word document into PDF document.
            PdfDocument pdfDocument = converter.ConvertToPDF(wordDocument);

            //Save the PDF file to file system.
            pdfDocument.Save("WordtoPDF.pdf");
            
            //Close the instance of document objects.
            pdfDocument.Close(true);
            wordDocument.Close();

            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("WordtoPDF.pdf");
        }
    }
}
