using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MergePDFs
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            //Creates a PDF document.
            PdfDocument finalDoc = new PdfDocument();

            //Loads the Pdf as a stream.
            Stream stream1 = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("MergePDFs.Assets.File1.pdf");
            Stream stream2 = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("MergePDFs.Assets.File2.pdf");
            
            //Creates a PDF stream for merging
            Stream[] streams = { stream1, stream2 };

            // Merges PDFDocument.
            PdfDocumentBase.Merge(finalDoc, streams);

            //Save the PDF document to stream
            MemoryStream stream = new MemoryStream();
            finalDoc.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;

            //Close the document.
            finalDoc.Close(true);

            //Save the stream as a file in the device and invoke it for viewing
            Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
        }
    }
}
