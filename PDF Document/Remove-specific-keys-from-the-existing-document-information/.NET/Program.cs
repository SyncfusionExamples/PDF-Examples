using Syncfusion.Pdf.Parsing;

namespace Remove_specific_keys_from_the_existing_document_information {
    internal class Program {
        static void Main(string[] args) {
            //Load an existing PDF document. 
            PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
            //Remove the document information properties. 
            document.DocumentInformation.Remove("Title");
            document.DocumentInformation.Remove("Author");
            document.DocumentInformation.Remove("Subject");
            document.DocumentInformation.Remove("Keywords");
            document.DocumentInformation.Remove("Creator");
            document.DocumentInformation.Remove("Producer");
            document.DocumentInformation.Remove("ModDate");
            document.DocumentInformation.Remove("CreationDate");
            
            //Save the document
            document.Save(Path.GetFullPath(@"Output/Output.pdf"));
            //Close the document.
            document.Close(true);
        }
    }
}