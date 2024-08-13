using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

namespace Import_tagged_structure_when_splitting_PDF_documents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Load an existing PDF file.
            PdfLoadedDocument loadDocument = new PdfLoadedDocument(new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open));
            //Subscribe to the document split event.
            loadDocument.DocumentSplitEvent += LoadDocument_DocumentSplitEvent;
            void LoadDocument_DocumentSplitEvent(object sender, PdfDocumentSplitEventArgs args)
            {
                //Save the resulting document.
                FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/" + Guid.NewGuid().ToString() + ".pdf"), FileMode.CreateNew);
                args.PdfDocumentData.CopyTo(outputStream);
                outputStream.Close();
            }
            //Create the split options object.
            PdfSplitOptions splitOptions = new PdfSplitOptions();
            //Enable the Split tags property.
            splitOptions.SplitTags = true;
            //Split the document by ranges.
            loadDocument.SplitByRanges(new int[,] { { 0, 1 }, { 1, 2 } }, splitOptions);

            //Close the document.
            loadDocument.Close(true);
        }
    }
}
