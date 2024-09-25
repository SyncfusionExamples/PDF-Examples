using Amazon.Lambda.Core;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Grid;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaProject;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public string FunctionHandler(string input, ILambdaContext context)
    {
        string filePath = Path.GetFullPath(@"Data/Input.pdf");
        //Open an existing PDF document.
        using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            PdfLoadedDocument document = new PdfLoadedDocument(stream);
            //Get the first page from a document.
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to the list.
            List<object> data = new List<object>();
            data.Add(new { Product_ID = "1001", Product_Name = "Bicycle", Price = "10,000" });
            data.Add(new { Product_ID = "1002", Product_Name = "Head Light", Price = "3,000" });
            data.Add(new { Product_ID = "1003", Product_Name = "Break wire", Price = "1,500" });
            
            //Assign data source.
            pdfGrid.DataSource = data;

            //Apply built-in table style.
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent3);

            //Draw the grid to the page of PDF document.
            pdfGrid.Draw(graphics, new RectangleF(40, 400, page.Size.Width - 80, 0));

            //Save the document into stream.
            MemoryStream memoryStream = new MemoryStream();
            document.Save(memoryStream);
            //Close the document.
            document.Close(true);
            //return the stream as base64 string
            return Convert.ToBase64String(memoryStream.ToArray());
        }

    }
}
