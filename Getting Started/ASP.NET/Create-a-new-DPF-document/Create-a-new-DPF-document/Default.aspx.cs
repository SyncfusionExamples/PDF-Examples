using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Create_a_new_DPF_document
{
    public partial class _Default : Page
    {
        protected void GeneratePDF(object sender, EventArgs e)
        {
            //Create a new PDF document. 
            using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document.
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for the page.
                PdfGraphics graphics = page.Graphics;

                //Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //Draw the text.
                graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

                // Open the document in browser after saving it.
                document.Save("Output.pdf", HttpContext.Current.Response, HttpReadType.Save);
            }
        }
    }
}