using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.Drawing;

namespace Open_and_save_PDF_document_Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            //Load PDF document as stream          
            Stream docStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("Open_and_save_PDF_document_Xamarin.Assets.Input.pdf");
            //Load an existing PDF document
            PdfLoadedDocument document = new PdfLoadedDocument(docStream);
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
            //Apply built-in table 
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent3);
            //Draw the grid to the page of PDF document
            pdfGrid.Draw(graphics, new RectangleF(40, 400, loadedPage.Size.Width - 80, 0));

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
