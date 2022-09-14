using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CreatePDFwithTable
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page.
            PdfPage page = document.Pages.Add();

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();

            //Add values to list
            List<object> data = new List<object>();
            Object row1 = new { ID = "E01", Name = "Clay" };
            Object row2 = new { ID = "E02", Name = "Thomas" };
            Object row3 = new { ID = "E03", Name = "Andrew" };
            Object row4 = new { ID = "E04", Name = "Paul" };
            Object row5 = new { ID = "E05", Name = "Gray" };

            //Add rows to datatable. 
            data.Add(row1);
            data.Add(row2);
            data.Add(row3);
            data.Add(row4);
            data.Add(row5);

            //Add list to IEnumerable.
            IEnumerable<object> dataTable = data;

            //Assign data source.
            pdfGrid.DataSource = dataTable;

            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new PointF(10, 10));

            //Save the PDF document to stream.
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            //Close the document.
            document.Close(true);

            //Save the stream as a file in the device and invoke it for viewing
            Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
        }
    }
}
