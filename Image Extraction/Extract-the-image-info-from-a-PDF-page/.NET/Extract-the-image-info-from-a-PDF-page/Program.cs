using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));

//Load the first page.
PdfPageBase pageBase = loadedDocument.Pages[0];

//Extracts all the images info from first page.
PdfImageInfo[] imagesInfo = pageBase.GetImagesInfo();

//Get each image and save to the separate file.
for (int i = 0; i < imagesInfo.Length; i++)
{
    Stream image = imagesInfo[i].ImageStream;
    File.WriteAllBytes(Path.GetFullPath(@"Output/" + i.ToString() + ".jpg"), (image as MemoryStream).ToArray());
}

//Close the document.
loadedDocument.Close(true);
