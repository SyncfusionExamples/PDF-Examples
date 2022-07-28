// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get the stream from an existing PDF document. 
FileStream docStream1 = new FileStream(Path.GetFullPath("../../../File1.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(docStream1);

//Get the stream from an existing PDF document.
FileStream docStream2 = new FileStream(Path.GetFullPath("../../../File2.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(docStream2);

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);