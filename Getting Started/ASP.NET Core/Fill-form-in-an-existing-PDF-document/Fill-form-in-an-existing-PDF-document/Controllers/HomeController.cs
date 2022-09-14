using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fill_form_in_an_existing_PDF_document.Models;
using System.IO;
using Syncfusion.Pdf.Parsing;
using Microsoft.AspNetCore.Hosting;

namespace Fill_form_in_an_existing_PDF_document.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult FillForm()
        {
            //Get stream from an existing PDF document. 
            FileStream docStream = new FileStream(_hostingEnvironment.WebRootPath + "/Data/Form.pdf", FileMode.Open, FileAccess.Read);

            //Load the PDF document. 
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

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

            //Write the PDF document to stream
            MemoryStream stream = new MemoryStream();
            loadedDocument.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;

            //Close the document.
            loadedDocument.Close(true);

            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";

            //Define the file name.
            string fileName = "output.pdf";

            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
