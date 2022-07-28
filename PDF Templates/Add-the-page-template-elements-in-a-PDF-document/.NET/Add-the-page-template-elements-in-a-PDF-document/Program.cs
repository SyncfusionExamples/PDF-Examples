// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Add a page to the PDF document.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create a header and draw the image.
RectangleF bounds = new RectangleF(0, 0, pdfDocument.Pages[0].GetClientSize().Width, 50);

//Create template element. 
PdfPageTemplateElement header = new PdfPageTemplateElement(bounds);

//Get stream from the image file. 
FileStream imageStream = new FileStream(Path.GetFullPath(Path.GetFullPath("../../../Logo.jpg")), FileMode.Open, FileAccess.Read);

//Load the image file. 
PdfImage image = new PdfBitmap(imageStream);

//Draw the image in the header.
header.Graphics.DrawImage(image, new Syncfusion.Drawing.PointF(0, 0), new SizeF(100, 50));

//Add the header at the top.
pdfDocument.Template.Top = header;

//Create a Page template that can be used as footer.
PdfPageTemplateElement footer = new PdfPageTemplateElement(bounds);

//Create the font. 
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 7);

//Create the brush. 
PdfBrush brush = new PdfSolidBrush(Syncfusion.Drawing.Color.Black);

//Create page number field.
PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);

//Create page count field.
PdfPageCountField count = new PdfPageCountField(font, brush);

//Add the fields in composite fields.
PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);
compositeField.Bounds = footer.Bounds;

//Draw the composite field in footer.
compositeField.Draw(footer.Graphics, new Syncfusion.Drawing.PointF(470, 40));

//Add the footer template at the bottom.
pdfDocument.Template.Bottom = footer;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);