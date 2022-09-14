using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Creating_a_PDF_document_with_table
{
    public partial class _Default : Page
    {
        protected void GeneratePDF(object sender, EventArgs e)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a new page.  
            PdfPage page = document.Pages.Add();

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();

            //Create a DataTable.
            DataTable dataTable = new DataTable();

            //Add columns to the DataTable.
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");

            //Add rows to the DataTable.
            dataTable.Rows.Add(new object[] { "E01", "Clay" });
            dataTable.Rows.Add(new object[] { "E02", "Thomas" });
            dataTable.Rows.Add(new object[] { "E03", "Andrew" });
            dataTable.Rows.Add(new object[] { "E04", "Paul" });
            dataTable.Rows.Add(new object[] { "E05", "Gary" });

            //Assign data source.
            pdfGrid.DataSource = dataTable;

            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new PointF(10, 10));

            //Open the document in browser after saving it.
            document.Save("Output.pdf", HttpContext.Current.Response, HttpReadType.Save);

            //Close the document
            document.Close(true);
        }
    }
}