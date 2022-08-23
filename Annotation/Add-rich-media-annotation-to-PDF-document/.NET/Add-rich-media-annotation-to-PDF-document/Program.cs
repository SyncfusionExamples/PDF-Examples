// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream inputStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document from stream.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);

//Get the page. 
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Create the PDF richmedia annotation. 
PdfRichMediaAnnotation richMediaAnnotation = new PdfRichMediaAnnotation(new RectangleF(0, 0, 200, 100));

//Set properties to the annotation. 
richMediaAnnotation.ActivationMode = PdfRichMediaActivationMode.Click;
richMediaAnnotation.PresentationStyle = PdfRichMediaPresentationStyle.Windowed;

//Set the richmedia content.
FileStream fileStream = new FileStream(Path.GetFullPath("../../../Sample_Video.mp4"), FileMode.Open, FileAccess.Read);
PdfRichMediaContent content = new PdfRichMediaContent("video", fileStream, "mp4");
richMediaAnnotation.Content = content;

//Create the appearance of the richmedia. 
richMediaAnnotation.Appearance.Normal.Graphics.DrawString("Click here to play video...", new PdfStandardFont(PdfFontFamily.Helvetica, 15), PdfBrushes.Blue, new RectangleF(0, 0, 200, 100), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));

//Add the annotation to the page. 
loadedPage.Annotations.Add(richMediaAnnotation);

//Save the document.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);