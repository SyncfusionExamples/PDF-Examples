using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the existing PdfLoadedRedactionAnnotation 
    PdfLoadedRedactionAnnotation annot = loadedDocument.Pages[0].Annotations[0] as PdfLoadedRedactionAnnotation;

    //set the bounds 
    List<RectangleF> bounds = new List<RectangleF>();
    bounds.Add(new RectangleF(100, 100, 50, 20));
    bounds.Add(new RectangleF(200, 150, 60, 25));
    annot.BoundsCollection = bounds;

    //set the inner color 
    annot.InnerColor = Color.Black;
    //set the border color 
    annot.BorderColor = Color.Green;
    //set the text color 
    annot.TextColor = Color.Yellow;
    //set the font 
    annot.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
    //set overlay text 
    annot.OverlayText = "Redact";
    //set text alignment 
    annot.TextAlignment = PdfTextAlignment.Center;
    annot.RepeatText = true;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
