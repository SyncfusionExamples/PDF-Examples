using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.IO;

PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf"));
//Flatten all form fields to make them part of the page graphics.
PdfLoadedForm loadedForm = loadedDocument.Form;
loadedForm.FlattenFields();

//Create a template from the first page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
PdfTemplate template = loadedPage.CreateTemplate();

//Create the destination PDF (no page margins so the template fills it edge-to-edge).
PdfDocument newDocument = new PdfDocument();
newDocument.PageSettings.Margins.All = 0;
PdfPage newPage = newDocument.Pages.Add();

//Draw the template so it fills the entire new page.
newPage.Graphics.DrawPdfTemplate(
    template,
    PointF.Empty,
    new SizeF(newPage.Size.Width, newPage.Size.Height));

//Save the result.
newDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close documents.
loadedDocument.Close(true);
newDocument.Close(true);