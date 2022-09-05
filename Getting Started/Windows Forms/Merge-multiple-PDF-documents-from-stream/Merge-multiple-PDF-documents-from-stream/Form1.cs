using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merge_multiple_PDF_documents_from_stream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Merge_PDFs(object sender, EventArgs e)
        {
            //Creates the destination document.
            PdfDocument finalDoc = new PdfDocument();

            //Get stream from the existing PDF documents. 
            Stream stream1 = File.OpenRead(Path.GetFullPath("../../Data/File1.pdf"));
            Stream stream2 = File.OpenRead(Path.GetFullPath("../../Data/File2.pdf"));

            // Creates a PDF stream for merging.
            Stream[] streams = { stream1, stream2 };

            // Merges PDFDocument.
            PdfDocumentBase.Merge(finalDoc, streams);

            //Saves the document.
            finalDoc.Save("Sample.pdf");

            //closes the document.
            finalDoc.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF Viewer 
            Process.Start("Sample.pdf");
        }
    }
}
