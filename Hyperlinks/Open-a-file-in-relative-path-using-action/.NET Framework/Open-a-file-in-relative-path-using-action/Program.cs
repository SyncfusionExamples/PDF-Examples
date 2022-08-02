using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_a_file_in_relative_path_using_action
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Create a new page.
            PdfPage page = document.Pages.Add();

            //Create the button field.
            PdfButtonField submitButton = new PdfButtonField(page, "submitButton");
            submitButton.Bounds = new RectangleF(100, 160, 100, 20);
            submitButton.Text = "Launch";

            //Create a the PdfLaunchAction.
            PdfLaunchAction launchAction = new PdfLaunchAction(@"..\..\Data\Test.txt", PdfFilePathType.Relative);

            //Set the launchAction to the submitButton.
            submitButton.Actions.GotFocus = launchAction;

            //Add the form field.
            document.Form.Fields.Add(submitButton);

            //Save the document to disk..
            document.Save("Output.pdf");

            //Close the document.
            document.Close();

            //This will open the PDF file so, the result will be seen in default PDF Viewer 
            Process.Start("Output.pdf");
        }
    }
}
