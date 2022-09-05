using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Merge_multiple_documents_from_disk
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
            //Creates the new PDF document.
            PdfDocument finalDoc = new PdfDocument();

            // Creates a string array of source files to be merged.
            string[] source = { System.IO.Path.GetFullPath("../../Data/File1.pdf"), System.IO.Path.GetFullPath("../../Data/File2.pdf") };

            //Merges PDFDocument.
            PdfDocument.Merge(finalDoc, source);

            //Saves the final document
            finalDoc.Save("MergedPDF.pdf");

            //Closes the document.
            finalDoc.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF Viewer 
            Process.Start("MergedPDF.pdf");
        }
    }
}
