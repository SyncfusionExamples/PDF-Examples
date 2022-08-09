// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Creates new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Add a page to the PDF document.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Set the document information title. 
pdfDocument.DocumentInformation.Title = "HeaderFooter";

//Creating artifact type for the header.
PdfArtifact headerArtifact = new PdfArtifact(PdfArtifactType.Pagination, new RectangleF(30, 40, 100, 100), new PdfAttached(PdfEdge.Top), PdfArtifactSubType.Header);

//Create a header and draw the image.
RectangleF bounds = new RectangleF(0, 0, pdfDocument.Pages[0].GetClientSize().Width, 50);

//Create header for PDF document. 
PdfPageTemplateElement header = new PdfPageTemplateElement(bounds);

//Adding artifact to the header.
header.PdfTag = headerArtifact;

//Get stream from the image file.
FileStream imageStream = new FileStream(Path.GetFullPath("../../../Autumn Leaves.jpg"), FileMode.Open, FileAccess.Read);

//Load the image file. 
PdfImage image = new PdfBitmap(imageStream);

//Draw the image in the header.         
header.Graphics.DrawImage(image, new PointF(200, 0), new SizeF(100, 50));

//Add the header at the top.
pdfDocument.Template.Top = header;

//Creating artifact type for the footer.
PdfArtifact footerArtifact = new PdfArtifact(PdfArtifactType.Pagination, new PdfAttached(PdfEdge.Bottom), PdfArtifactSubType.Footer);

//Create a Page template that can be used as footer.
PdfPageTemplateElement footer = new PdfPageTemplateElement(bounds);

//Set the font and brush. 
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 7);
PdfBrush brush = new PdfSolidBrush(Color.Black);

//Create page number field.
PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);

//Create page count field.
PdfPageCountField count = new PdfPageCountField(font, brush);

//Add the fields in composite fields.
PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);

//Set the bounds for footer. 
compositeField.Bounds = footer.Bounds;

//Adding artifact type to the footer.
compositeField.PdfTag = footerArtifact;

//Draw the composite field in footer.
compositeField.Draw(footer.Graphics, new PointF(470, 40));

//Add the footer template at the bottom.
pdfDocument.Template.Bottom = footer;

//Draw text in PDF page. 
pdfPage.Graphics.DrawString("Hello World!!!", new PdfStandardFont(PdfFontFamily.Helvetica, 20), brush, new PointF(0,0));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);
