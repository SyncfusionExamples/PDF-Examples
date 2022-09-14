using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Creating_a_PDF_document_with_table
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GeneratePDF(object sender, RoutedEventArgs e)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page.
            PdfPage page = document.Pages.Add();

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();

            //Create a DataTable.
            DataTable dataTable = new DataTable();

            //Add columns to the DataTable
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

            //Save the document.
            document.Save("Output.pdf");

            //close the document
            document.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF Viewer 
            Process.Start("Output.pdf");
        }
    }
}
