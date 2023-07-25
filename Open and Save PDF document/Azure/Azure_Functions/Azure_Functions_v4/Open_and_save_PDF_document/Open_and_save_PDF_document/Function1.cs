using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Host;
using Syncfusion.Pdf.Parsing;
using System.Reflection;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using Syncfusion.Drawing;
using System.Net.Http.Headers;
using Syncfusion.Pdf.Graphics;

namespace Open_and_save_PDF_document
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            TraceWriter log, ExecutionContext context)
        {
            //Load an existing PDF document from the disk.
            var assembly = Assembly.GetExecutingAssembly();
            var docStream = assembly.GetManifestResourceStream("Open_and_save_PDF_document.Data.Input.pdf");
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            //Get the first page from the document.
            PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
            //Create graphics from PDF page. 
            PdfGraphics graphics = loadedPage.Graphics;

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
            pdfGrid.Draw(graphics, new RectangleF(40, 400, loadedPage.Size.Width - 80, 0));

            //Save and close the PDF document  
            MemoryStream ms = new MemoryStream();
            loadedDocument.Save(ms);
            loadedDocument.Close();
            ms.Position = 0;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(ms.ToArray());
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "Sample.pdf"
            };
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            return response;
        }
    }
}
