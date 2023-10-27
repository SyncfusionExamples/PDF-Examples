using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf;

namespace Compress_secured_PDF_NET {
    internal class Program {
        static void Main(string[] args) {
            //Load existing PDF document.
            FileStream fileStream = new FileStream(Path.GetFullPath("../../../Data/SecurePDF.pdf"), FileMode.Open, FileAccess.Read);
            PdfLoadedDocument document = new PdfLoadedDocument(fileStream, "syncfusion");

            //Create a new compression option.
            PdfCompressionOptions options = new PdfCompressionOptions();
            //Enable the compress image.
            options.CompressImages = true;
            //Set the image quality.
            options.ImageQuality = 50;

            //Assign the compression option to the document
            document.Compress(options);
            //Create file stream.
            using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            //Close the document.
            document.Close(true);
        }
    }
}