// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Parsing;
using System.Drawing;
using System.Drawing.Imaging;

//Get stream from an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the first page.
PdfPageBase pageBase = loadedDocument.Pages[0];

//Extract images from first page.
Stream[] extractedImages = pageBase.ExtractImages();

//Get each image and save to the separate file. 
for(int i=0; i<extractedImages.Length; i++)
{
    File.WriteAllBytes("Output/Output" + i.ToString() + ".jpg", (extractedImages[i] as MemoryStream).ToArray());
}

//Close the document.
loadedDocument.Close(true);
