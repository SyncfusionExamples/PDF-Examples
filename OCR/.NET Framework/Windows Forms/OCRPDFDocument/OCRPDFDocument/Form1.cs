using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Parsing;
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

namespace OCRPDFDocument
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string tesseractBinariespath = Path.GetFullPath("../../../../../TesseractBinaries/");
        string tessdataPath = Path.GetFullPath("../../../../../Tessdata/");

        private void button1_Click(object sender, EventArgs e)
        {
            //Initialize the OCR processor by providing the path of tesseract binaries(SyncfusionTesseract.dll and liblept168.dll)
            using (OCRProcessor processor = new OCRProcessor(tesseractBinariespath + "/4.0/x86/"))
            {
                //Load the PDF document
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../Data/Input.pdf");

                //Set OCR language to process
                processor.Settings.Language = Languages.English;

                //Set the tesseract version 
                processor.Settings.TesseractVersion = TesseractVersion.Version4_0;

                //Process OCR by providing the PDF document and Tesseract data
                processor.PerformOCR(loadedDocument, tessdataPath);

                //Save the OCR processed PDF document in the disk
                loadedDocument.Save("OCR.pdf");
                loadedDocument.Close(true);
            }

            Process.Start("OCR.pdf");
        }
    }
}
