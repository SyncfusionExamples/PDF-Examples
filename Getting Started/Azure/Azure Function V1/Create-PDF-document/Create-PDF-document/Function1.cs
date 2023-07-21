using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace Create_PDF_document
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log, ExecutionContext context)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                //Create a new PDF document.
                PdfDocument document = new PdfDocument();
                //Set the page size.
                document.PageSettings.Size = PdfPageSize.A4;
                //Add a page to the document.
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for the page.
                PdfGraphics graphics = page.Graphics;
                //Load the image from the disk.
                var assembly = Assembly.GetExecutingAssembly();
                var imageStream = assembly.GetManifestResourceStream("Create-PDF-document.Data.AdventureCycle.jpg");
                PdfBitmap image = new PdfBitmap(imageStream);
                //Draw an image.
                graphics.DrawImage(image, new RectangleF(130, 0, 250, 100));

                //Draw header text. 
                graphics.DrawString("Adventure Works Cycles", new PdfStandardFont(PdfFontFamily.TimesRoman, 20, PdfFontStyle.Bold), PdfBrushes.Gray, new PointF(150, 150));

                //Add paragraph. 
                string text = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";
                //Create a text element with the text and font.
                PdfTextElement textElement = new PdfTextElement(text, new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
                //Draw the text in the first column.
                textElement.Draw(page, new RectangleF(0, 200, page.GetClientSize().Width, page.GetClientSize().Height));

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
                pdfGrid.Draw(graphics, new RectangleF(0, 300, page.Size.Width - 80, 0));

                //Save and close the PDF document  
                document.Save(ms);
                document.Close();
                ms.Position = 0;
            }
            catch(Exception ex)
            {
                //Create a new PDF document.
                PdfDocument document = new PdfDocument();
                //Add a page to the document.
                PdfPage page = document.Pages.Add();
                //Create PDF graphics for the page.
                PdfGraphics graphics = page.Graphics;

                //Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 5);
                //Draw the text.
                graphics.DrawString(ex.ToString(), font, PdfBrushes.Black, new PointF(0, 0));

                //Creating the stream object.
                ms = new MemoryStream();
                //Save the document into memory stream.
                document.Save(ms);
                //Close the document.
                document.Close(true);
                ms.Position = 0;
            }

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
