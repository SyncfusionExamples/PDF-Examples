using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(Path.GetFullPath(@"Data/File1.pdf"));

//Load the PDF document. 
PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(Path.GetFullPath(@"Data/File2.pdf"));

//Create the new document.
PdfDocument document = new PdfDocument();

//Add the new pages to PDF document. 
PdfPage page1 = document.Pages.Add();
PdfPage page2 = document.Pages.Add();

//Create a template from the first document.
PdfPageBase loadedPage = loadedDocument1.Pages[0];

//Create template from the existing page. 
PdfTemplate template = loadedPage.CreateTemplate();

//Draw the loaded template into new document.
page1.Graphics.DrawPdfTemplate(template, new PointF(0, 0), new SizeF(500, 700));

//Create a template from the second document.
loadedPage = loadedDocument2.Pages[0];

//Create template from the existing PDF page. 
template = loadedPage.CreateTemplate();

//Draw the loaded template into new document.
page2.Graphics.DrawPdfTemplate(template, new PointF(10, 10), new SizeF(400, 500));

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
document.Close(true);
loadedDocument1.Close(true);
loadedDocument2.Close(true);
