using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Create_PDF_document_with_image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GeneratePDF(object sender, EventArgs e)
        {
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();

            //Add a page to the document.
            PdfPage page = doc.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Load the image from the disk.
            PdfBitmap image = new PdfBitmap("../../Data/Autumn Leaves.jpg");

            //Draw the image
            graphics.DrawImage(image, 0, 0);

            //Save the document.
            doc.Save("Output.pdf");

            //Close the document.
            doc.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF Viewer. 
            Process.Start("Output.pdf");
        }
    }
}
