using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/File1.pdf"));
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

//Save the PDF document
finalDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the documents.
finalDocument.Close(true);