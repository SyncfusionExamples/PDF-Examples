using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

namespace Get_images_from_the_existing_signed_signature_field {
    internal class Program {
        static void Main(string[] args) {
            //Load an existing PDF file.
            FileStream fileStream = new FileStream(Path.GetFullPath("Data/Input.pdf"), FileMode.Open, FileAccess.Read);
            PdfLoadedDocument ldoc = new PdfLoadedDocument(fileStream);
            //Get the existing signed signature field.
            PdfLoadedSignatureField loadedSignature = ldoc.Form.Fields[0] as PdfLoadedSignatureField;
            //Get the image streams.
            Stream[] imageStreams = loadedSignature.GetImages();
            for (int i = 0; i < imageStreams.Length; i++) {
                File.WriteAllBytes("Output/" + i.ToString() + ".jpg", (imageStreams[i] as MemoryStream).ToArray());
            }
            //Close a PDF document.
            ldoc.Close(true);
        }
    }
}