using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PDF_generation_through_ASMX_based_web_app.Services
{
    /// <summary>
    /// Summary description for PdfService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PdfService : System.Web.Services.WebService
    {

        [WebMethod]

        public byte[] GenerateDocument(string empId, string name)
        {

            // Create a new PDF document
            using (PdfDocument document = new PdfDocument())
            {
                //Add page. 
                PdfPage pdfPage = document.Pages.Add();

                //Create a new PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();
                //Add three columns.
                pdfGrid.Columns.Add(3);
                //Add header.
                pdfGrid.Headers.Add(1);
                PdfGridRow pdfGridHeader = pdfGrid.Headers[0];
                pdfGridHeader.Cells[0].Value = "Employee ID";
                pdfGridHeader.Cells[1].Value = "Employee Name";
                pdfGridHeader.Cells[2].Value = "Salary";

                //Add rows.
                PdfGridRow pdfGridRow = pdfGrid.Rows.Add();
                pdfGridRow.Cells[0].Value = empId;
                pdfGridRow.Cells[1].Value = name;
                pdfGridRow.Cells[2].Value = "$10,000";
                //Draw the PdfGrid.
                pdfGrid.Draw(pdfPage, PointF.Empty);

                // Save to memory stream
                using (MemoryStream stream = new MemoryStream())
                {
                    document.Save(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
