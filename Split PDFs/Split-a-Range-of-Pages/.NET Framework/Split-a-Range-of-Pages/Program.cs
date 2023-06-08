using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split_a_Range_of_Pages
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] values = new int[,] { { 2, 5 }, { 8, 10 } };
            //Load document.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../Input.pdf");

            //Sets pattern.
            const string destinationFilePattern = "Output" + "{0}.pdf";

            //Split the pages into fixed number.
            loadedDocument.SplitByRanges(destinationFilePattern, values);
            //close the document
            loadedDocument.Close(true);
        }
    }
}
