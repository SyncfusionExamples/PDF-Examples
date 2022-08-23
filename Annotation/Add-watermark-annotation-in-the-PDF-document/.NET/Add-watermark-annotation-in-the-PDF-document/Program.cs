// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Creates PDF watermark annotation.
PdfWatermarkAnnotation watermark = new PdfWatermarkAnnotation(new RectangleF(50, 50, 400, 100));

//Sets properties to the annotation.
watermark.Opacity = 0.5f;

//Create the appearance of watermark.
watermark.Appearance.Normal.Graphics.DrawString("Watermark Text", new PdfStandardFont(PdfFontFamily.Helvetica, 20), PdfBrushes.Red, new RectangleF(0, 0, 200, 50), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));

//Adds the annotation to page.
loadedPage.Annotations.Add(watermark);

//Save the document.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);