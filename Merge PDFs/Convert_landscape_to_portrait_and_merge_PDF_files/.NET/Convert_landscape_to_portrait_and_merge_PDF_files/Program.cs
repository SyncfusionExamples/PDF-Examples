// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System.Reflection.Metadata;
using Syncfusion.Pdf.Graphics;
using System.Xml.Linq;
using Syncfusion.Drawing;

//Create a new PDF document.
PdfDocument finalDocument = new PdfDocument();
//Change the page orientation to landscape. 
finalDocument.PageSettings.Orientation = PdfPageOrientation.Landscape;
//Set margin to 0 in PDF document. 
finalDocument.PageSettings.Margins.All = 0;

//Load an existing PDF document. 
FileStream stream1 = new FileStream(Path.GetFullPath(@"Data/File1.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream1);

for (int i = 0; i < loadedDocument.Pages.Count; i++)
{
    //Load the page.
    PdfLoadedPage loadedPage = loadedDocument.Pages[i] as PdfLoadedPage;
    //Create the template from the page.
    PdfTemplate template = loadedPage.CreateTemplate();
    //Add the page.
    PdfPage page = finalDocument.Pages.Add();
    //Create the graphics.
    PdfGraphics graphics = page.Graphics;
    //Draw the template.
    graphics.DrawPdfTemplate(template, PointF.Empty, new SizeF(page.Size.Width, page.Size.Height));
}

//Load an existing PDF document. 
FileStream stream2 = new FileStream(Path.GetFullPath(@"Data/File2.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument2 = new PdfLoadedDocument(stream2);
finalDocument.ImportPageRange(loadedDocument2, 0, loadedDocument2.Pages.Count - 1);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    finalDocument.Save(outputFileStream);
}

//Close the document.
finalDocument.Close(true);
loadedDocument.Close(true);
loadedDocument2.Close(true);
