using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Convert_HTML_to_TaggedPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(HTMLToTaggedPDF);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        private static void HTMLToTaggedPDF()
        {
            //Creates a new PdfDocument.
            PdfDocument document = new PdfDocument();

            //Creates a new instance of HtmlConverter class.
            using (HtmlConverter html = new HtmlConverter())
            {
                //Enable JavaScript.
                html.EnableJavaScript = true;

                //Converts to Tagged PDF document.
                html.ConvertToTaggedPDF(document, "http://www.google.com");
            }

            //Saves and closes the document.
            document.Save("Sample.pdf");
            document.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF viewer.
            Process.Start("Sample.pdf");
        }
    }
}
