using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Open_and_save_PDF_document
{
    public partial class _Default : Page
    {
        protected void OpenAndSaveDocument(object sender, EventArgs e)
        {
            //Load an existing PDF document.
            PdfLoadedDocument document = new PdfLoadedDocument(Server.MapPath("~/App_Data/Input.pdf"));
            //Get the first page from a document.
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to the list.
            List<object> data = new List<object>();
            Object row1 = new { Product_ID = "1001", Product_Name = "Bicycle", Price = "10,000" };
            Object row2 = new { Product_ID = "1002", Product_Name = "Head Light", Price = "3,000" };
            Object row3 = new { Product_ID = "1003", Product_Name = "Break wire", Price = "1,500" };
            data.Add(row1);
            data.Add(row2);
            data.Add(row3);
            //Add list to IEnumerable.
            IEnumerable<object> dataTable = data;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Apply built-in table style.
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent3);
            //Draw the grid to the page of PDF document.
            pdfGrid.Draw(graphics, new RectangleF(40, 400, page.Size.Width - 80, 0));

            //Save the document.
            document.Save("Output.pdf", HttpContext.Current.Response, HttpReadType.Save);
            //Close the document.
            document.Close(true);
        }
    }
}