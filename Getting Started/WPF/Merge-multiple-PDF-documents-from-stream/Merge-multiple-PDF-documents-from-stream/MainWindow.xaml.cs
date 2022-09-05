using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Merge_multiple_PDF_documents_from_stream
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

        private void MergePDFs(object sender, RoutedEventArgs e)
        {
            //Creates the destination document.
            PdfDocument finalDoc = new PdfDocument();

            //Get stream from an existing PDF document. 
            Stream stream1 = File.OpenRead(System.IO.Path.GetFullPath("../../Data/file1.pdf"));
            Stream stream2 = File.OpenRead(System.IO.Path.GetFullPath("../../Data/file2.pdf"));

            //Creates a PDF stream for merging.
            Stream[] streams = { stream1, stream2 };

            //Merges PDFDocument.
            PdfDocumentBase.Merge(finalDoc, streams);

            //Saves the document
            finalDoc.Save("Sample.pdf");

            //Closes the document.
            finalDoc.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF Viewer 
            Process.Start("Sample.pdf");
        }
    }
}
