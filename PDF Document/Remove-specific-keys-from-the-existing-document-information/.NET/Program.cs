using Syncfusion.Pdf.Parsing;

namespace Remove_specific_keys_from_the_existing_document_information {
    internal class Program {
        static void Main(string[] args) {
            //Load an existing PDF document. 
            FileStream fileStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
            PdfLoadedDocument document = new PdfLoadedDocument(fileStream);
            //Remove the document information properties. 
            document.DocumentInformation.Remove("Title");
            document.DocumentInformation.Remove("Author");
            document.DocumentInformation.Remove("Subject");
            document.DocumentInformation.Remove("Keywords");
            document.DocumentInformation.Remove("Creator");
            document.DocumentInformation.Remove("Producer");
            document.DocumentInformation.Remove("ModDate");
            document.DocumentInformation.Remove("CreationDate");

            //Creating the stream object. 
            MemoryStream stream = new MemoryStream();
            //Save the document into stream.
            document.Save(stream);
            File.WriteAllBytes(Path.GetFullPath(@"Output/Output.pdf"), stream.ToArray());
            //Close the document.
            document.Close(true);
        }
    }
}