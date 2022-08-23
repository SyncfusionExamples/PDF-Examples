using Syncfusion.Pdf.Xfa;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattening_XFA_form_fields
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load an existing PDF document.
            PdfLoadedXfaDocument ldoc = new PdfLoadedXfaDocument("../../Data/Input.pdf");

            //Set flatten.
            ldoc.Flatten = true;

            //Save the document.
            ldoc.Save("Output.pdf");

            //Close the document.
            ldoc.Close();

            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("Output.pdf");
        }
    }
}
