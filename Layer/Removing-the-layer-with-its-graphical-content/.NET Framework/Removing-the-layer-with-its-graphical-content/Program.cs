using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Removing_the_layer_with_its_graphical_content
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the existing PDF document.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath("../../Data/Layers.pdf"));

            //Get the layer collection.
            PdfDocumentLayerCollection layers = loadedDocument.Layers;

            if (layers.Count > 0)
            {
                if (layers[0].Layers.Count > 0)
                {
                    //Remove the first child layer with graphical content.
                    layers[0].Layers.RemoveAt(0, true);
                }
            }

            //Save the PDF document.
            loadedDocument.Save("Output.pdf");

            //Close the instance of PdfLoadedDocument.
            loadedDocument.Close(true);


            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("Output.pdf");

        }
    }
}
