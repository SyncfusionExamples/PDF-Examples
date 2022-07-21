// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the first page.
PdfPageBase pageBase = loadedDocument.Pages[0];

//Extract images from the first page.
PdfImageInfo[] imageInfo = loadedDocument.Pages[0].GetImagesInfo();

//Remove the Image.
pageBase.RemoveImage(imageInfo[0]);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream
    loadedDocument.Save(outputFileStream);
}

//Close the document
loadedDocument.Close(true);
