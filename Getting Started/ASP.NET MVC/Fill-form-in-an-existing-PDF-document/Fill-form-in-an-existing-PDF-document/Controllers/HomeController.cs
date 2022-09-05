using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fill_form_in_an_existing_PDF_document.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FillForm()
        {
            //Load the existing PDF document. 
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Server.MapPath("~/App_Data/Form.pdf"));

            //Loads the form.
            PdfLoadedForm form = loadedDocument.Form;

            //Fills the textbox field by using index.
            (form.Fields[0] as PdfLoadedTextBoxField).Text = "John";

            //Fills the textbox fields by using field name.
            (form.Fields["Last Name"] as PdfLoadedTextBoxField).Text = "Doe";
            (form.Fields["Address"] as PdfLoadedTextBoxField).Text = " John Doe \n 123 Main St \n Anytown, USA";

            //Loads the radio button group.
            PdfLoadedRadioButtonItemCollection radioButtonCollection = (form.Fields["Gender"] as PdfLoadedRadioButtonListField).Items;

            //Checks the 'Male' option.
            radioButtonCollection[0].Checked = true;

            //Loads the radio button group.
            PdfLoadedRadioButtonItemCollection radioButtonCollection1 = (form.Fields["Occupation"] as PdfLoadedRadioButtonListField).Items;

            //Checks the 'Student' option.
            radioButtonCollection1[0].Checked = true;

            //Open the document in browser after saving it.
            loadedDocument.Save("Output.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save);
            loadedDocument.Close(true);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}