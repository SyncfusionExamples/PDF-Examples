using Syncfusion.Pdf.Parsing;
using System.IO;

//Initialize the PDF document extractor.
PdfDocumentExtractor documentExtractor = new PdfDocumentExtractor();
//Load the PDF document.
FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read);
documentExtractor.Load(docStream);

//Get the page count.
int pageCount = documentExtractor.PageCount;
//Extract images from the PDF document.
Stream[] images = documentExtractor.ExtractImages();

for(int i=0;i<images.Length;i++)
{
    //Save the image.
    FileStream imageStream = new FileStream(Path.GetFullPath(@"Output/" + i + ".png"), FileMode.Create, FileAccess.Write);
    images[i].CopyTo(imageStream);
    imageStream.Dispose();
}

////Extract images by page range.
//Stream[] streams = documentExtractor.ExtractImages(2, 6);

//Release all resources used by the PDF Image extractor.
documentExtractor.Dispose();

