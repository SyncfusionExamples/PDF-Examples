// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get first page from document.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Create PDF graphics for the page.
PdfGraphics graphics = loadedPage.Graphics;

//Get stream from the existing image file. 
FileStream imageStream = new FileStream(Path.GetFullPath("../../../Autumn Leaves.jpg"), FileMode.Open, FileAccess.Read);

//Load the image from the disk.
PdfBitmap image = new PdfBitmap(imageStream);

//Draw the image. 
graphics.DrawImage(image, 0, 0);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);

