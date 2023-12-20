using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace Remove_Unused_Resources_when_Splitting_PDF_Documents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Load the existing PDF file.
            PdfLoadedDocument loadDocument = new PdfLoadedDocument(new FileStream("../../../Input.pdf", FileMode.Open));
            //Subscribe to the document split event.
            loadDocument.DocumentSplitEvent += LoadDocument_DocumentSplitEvent;
            void LoadDocument_DocumentSplitEvent(object sender, PdfDocumentSplitEventArgs args)
            {
                //Save the resulting document.
                FileStream outputStream = new FileStream(Guid.NewGuid().ToString() + ".pdf", FileMode.CreateNew);
                args.PdfDocumentData.CopyTo(outputStream);
                outputStream.Close();
            }
            //Create the split options object.
            PdfSplitOptions splitOptions = new PdfSplitOptions();
            //Enable the removal of unused resources property.
            splitOptions.RemoveUnusedResources = true;
            //Split the document by ranges.
            loadDocument.SplitByRanges(new int[,] { { 0, 5 }, { 5, 10 } }, splitOptions);
            //Close the document.
            loadDocument.Close(true);
        }
    }
}
