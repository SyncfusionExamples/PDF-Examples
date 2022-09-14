using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Fill_a_form_in_an_existing_PDF_document
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FillForm(object sender, EventArgs e)
        {
            //Loads the PDF form.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(@"../../Data/Form.pdf");

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

            //Saves and closes the document
            loadedDocument.Save("Output.pdf");
            loadedDocument.Close(true);
			
			//This will open the PDF file so, the result will be seen in default PDF Viewer 
            Process.Start("Form.pdf");
        }
    }
}
