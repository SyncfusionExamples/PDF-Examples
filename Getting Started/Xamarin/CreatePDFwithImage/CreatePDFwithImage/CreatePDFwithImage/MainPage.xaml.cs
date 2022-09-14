using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CreatePDFwithImage
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

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Load the image as stream
            Stream imageStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("CreatePDFwithImage.Assets.Autumn Leaves.jpg");
            
            //Load the image from the disk.
            PdfBitmap image = new PdfBitmap(imageStream);
            
            //Draw the image.
            graphics.DrawImage(image, 0, 0);
            
            //Save the document to the stream.
            MemoryStream stream = new MemoryStream();
            
            //Save the document.
            document.Save(stream);

            //Close the document.
            document.Close(true);

            //Save the stream as a file in the device and invoke it for viewing
            Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
        }
    }
}
