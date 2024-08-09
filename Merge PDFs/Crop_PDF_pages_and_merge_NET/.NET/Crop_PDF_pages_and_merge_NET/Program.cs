// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

//Get the stream from an existing PDF document.
FileStream stream1 = new FileStream(Path.GetFullPath(@"Data/File1.pdf"), FileMode.Open, FileAccess.Read);
//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream1);
//Load the page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
//Create the template from the page.
PdfTemplate template = loadedPage.CreateTemplate();
//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Calculate height from inches.
float inches = 6f;
float height = inches * 72;
//Set the document margin and height.
document.PageSettings.Height = height;
//Add the page to new PDF docment.
PdfPage page = document.Pages.Add();
//Create the graphics.
PdfGraphics graphics = page.Graphics;
//Draw the template.
graphics.DrawPdfTemplate(template, new PointF(0, 0));

//Save the PDF document to stream.
MemoryStream stream = new MemoryStream();
document.Save(stream);
//Close the PDF documents.
document.Close(true);
loadedDocument.Close(true);

//Creates a PDF document.
PdfDocument finalDocument = new PdfDocument();
//Get the stream from an existing PDF documents.
FileStream stream2 = new FileStream(Path.GetFullPath(@"Data/File2.pdf"), FileMode.Open, FileAccess.Read);
Stream[] streams = { stream, stream2 };
//Merges PDF documents.
PdfDocumentBase.Merge(finalDocument, streams);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    finalDocument.Save(outputFileStream);
}

//Close the documents.
finalDocument.Close(true);