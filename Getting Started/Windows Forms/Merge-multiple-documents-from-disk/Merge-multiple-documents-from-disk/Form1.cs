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

namespace Merge_multiple_documents_from_disk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Merge_PDFs(object sender, EventArgs e)
        {
            //Creates the new PDF document.
            PdfDocument finalDoc = new PdfDocument();

            // Creates a string array of source files to be merged.
            string[] source = { Path.GetFullPath("../../Data/File1.pdf"), Path.GetFullPath("../../Data/File2.pdf") };

            // Merges PDFDocument.
            PdfDocument.Merge(finalDoc, source);

            //Saves the final document
            finalDoc.Save("MergedPDF.pdf");

            //closes the document
            finalDoc.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF Viewer 
            Process.Start("MergedPDF.pdf");
        }
    }
}
