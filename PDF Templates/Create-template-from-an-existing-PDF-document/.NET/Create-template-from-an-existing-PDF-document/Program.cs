// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Create the template from the page.
PdfTemplate template = loadedPage.CreateTemplate();

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Set the document margin.
document.PageSettings.SetMargins(2);

//Add the page.
PdfPage page = document.Pages.Add();

//Create the graphics.
PdfGraphics graphics = page.Graphics;

//Draw the template.
graphics.DrawPdfTemplate(template, Syncfusion.Drawing.PointF.Empty, new Syncfusion.Drawing.SizeF(page.Size.Width / 2, page.Size.Height));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the documents.
loadedDocument.Close(true);
document.Close(true);
