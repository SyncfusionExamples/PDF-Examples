using Syncfusion.Pdf.Parsing;

namespace Split_by_FixedNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Load document.
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../Input.pdf");

            //Sets pattern.
            const string destinationFilePattern = "Output" + "{0}.pdf";

            //Split the pages into fixed number.
            loadedDocument.SplitByFixedNumber(destinationFilePattern, 4);

            //close the document
            loadedDocument.Close(true);
        }
    }
}
