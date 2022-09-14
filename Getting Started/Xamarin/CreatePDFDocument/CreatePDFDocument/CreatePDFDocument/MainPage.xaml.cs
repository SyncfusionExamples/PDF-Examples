using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreatePDFDocument
{
    public partial class MainPage : Xamarin.Forms.ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

            //Save the document to the stream. 
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            //Close the document.
            document.Close(true);

            //Save the stream as a file in the device and invoke it for viewing.
            Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
        }
    }
}
