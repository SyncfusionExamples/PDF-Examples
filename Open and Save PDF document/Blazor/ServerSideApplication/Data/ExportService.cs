using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Parsing;

namespace ServerSideApplication.Data
{
    public class ExportService
    {
        public static MemoryStream LoadAndSavePDF(WeatherForecast[] forecasts)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("Forecast cannot be null");
            }

            //Load an existing PDF document. 
            string filePath = "wwwroot/Data/Input.pdf";
            FileStream fileStream = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            PdfLoadedDocument document = new PdfLoadedDocument(fileStream);

            //Load the existing page
            PdfLoadedPage loadedPage = document.Pages[0] as PdfLoadedPage;
            //Create PDF graphics for the page
            PdfGraphics graphics = loadedPage.Graphics;

            //Create a PdfGrid
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to the list
            List<object> data = new List<object>();
            Object row1 = new { Product_ID = "1001", Product_Name = "Bicycle", Price = "10,000" };
            Object row2 = new { Product_ID = "1002", Product_Name = "Head Light", Price = "3,000" };
            Object row3 = new { Product_ID = "1003", Product_Name = "Break wire", Price = "1,500" };
            data.Add(row1);
            data.Add(row2);
            data.Add(row3);
            //Add list to IEnumerable
            IEnumerable<object> dataTable = data;
            //Assign data source
            pdfGrid.DataSource = dataTable;
            //Apply built-in table style
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent3);
            //Draw the grid to the page of PDF document
            pdfGrid.Draw(graphics, new RectangleF(40, 400, loadedPage.Size.Width - 80, 0));

            using (MemoryStream stream = new MemoryStream())
            {
                //Saving the PDF document into the stream
                document.Save(stream);
                //Closing the PDF document
                document.Close(true);
                return stream;
            }
        }
    }
}
