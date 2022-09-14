using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merge_multiple_PDF_documents
{
    public partial class _Default : Page
    {
        protected void MergePDF(object sender, EventArgs e)
        {
            //Creates the new PDF document.
            PdfDocument finalDoc = new PdfDocument();

            //Creates a string array of source files to be merged.
            string[] source = System.IO.Directory.GetFiles(Server.MapPath("~/App_Data/"), "*.pdf");

            //Merges PDFDocument.
            PdfDocument.Merge(finalDoc, source);

            //Open the document in browser after saving it.
            finalDoc.Save("Output.pdf", HttpContext.Current.Response, HttpReadType.Save);

            //Closes the document.
            finalDoc.Close(true);
        }
    }
}