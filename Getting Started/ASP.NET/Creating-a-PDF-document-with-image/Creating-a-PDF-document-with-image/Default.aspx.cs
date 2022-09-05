using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Creating_a_PDF_document_with_image
{
    public partial class _Default : Page
    {
        protected void GeneratePDF(object sender, EventArgs e)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Load the image from the disk.
            PdfBitmap image = new PdfBitmap(Server.MapPath("~/App_Data/Autumn Leaves.jpg"));

            //Draw the image.
            graphics.DrawImage(image, 0, 0);

            //Save the document.
            document.Save("Output.pdf", HttpContext.Current.Response, HttpReadType.Save);

            //Close the document.
            document.Close(true);
        }
    }
}