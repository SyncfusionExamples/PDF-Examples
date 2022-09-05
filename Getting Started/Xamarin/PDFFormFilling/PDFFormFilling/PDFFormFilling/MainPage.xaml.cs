using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDFFormFilling
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            //Get stream from an existing PDF document. 
            Stream pdfStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("PDFFormFilling.Assets.Form.pdf");

            //Load the PDF document. 
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(pdfStream);

            //Loads the form
            PdfLoadedForm form = loadedDocument.Form;

            //Fills the textbox field by using index
            (form.Fields[0] as PdfLoadedTextBoxField).Text = "John";

            //Fills the textbox fields by using field name
            (form.Fields["Last Name"] as PdfLoadedTextBoxField).Text = "Doe";
            (form.Fields["Address"] as PdfLoadedTextBoxField).Text = " John Doe \n 123 Main St \n Anytown, USA";

            //Loads the radio button group
            PdfLoadedRadioButtonItemCollection radioButtonCollection = (form.Fields["Gender"] as PdfLoadedRadioButtonListField).Items;

            //Checks the 'Male' option
            radioButtonCollection[0].Checked = true;

            //Loads the radio button group
            PdfLoadedRadioButtonItemCollection radioButtonCollection1 = (form.Fields["Occupation"] as PdfLoadedRadioButtonListField).Items;

            //Checks the 'Male' option
            radioButtonCollection1[0].Checked = true;

            //Save the document to the stream
            MemoryStream stream = new MemoryStream();
            loadedDocument.Save(stream);

            //Close the document
            loadedDocument.Close(true);

            //Save the stream as a file in the device and invoke it for viewing
            Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
        }
    }
}
