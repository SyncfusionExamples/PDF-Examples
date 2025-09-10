using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

// Load the existing PDF document using FileStream
using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    // Load the PDF document from the input stream
    using (PdfLoadedDocument ldoc = new PdfLoadedDocument(inputStream))
    {
        //Load the existing PdfLoadedRedactionAnnotation 
        PdfLoadedRedactionAnnotation annot = ldoc.Pages[0].Annotations[0] as PdfLoadedRedactionAnnotation;

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

        // Save the modified document using a new FileStream
        using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
        {
            // Save changes to a new PDF file
            ldoc.Save(outputStream);
        }
        // Close the document and release resources
        ldoc.Close(true);
    }
}
