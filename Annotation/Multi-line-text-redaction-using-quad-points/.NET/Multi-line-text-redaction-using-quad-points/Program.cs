using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Create a new page. 
PdfPage page = document.Pages.Add();
//Creates a new Redaction annotation. 
PdfRedactionAnnotation annot = new PdfRedactionAnnotation();

//set the bounds collection of redaction annotation. 
List<RectangleF> bounds = new List<RectangleF>();
bounds.Add(new RectangleF(100, 100, 50, 20));
bounds.Add(new RectangleF(200, 150, 60, 25));
annot.BoundsCollection = bounds;

//set the innercolor 
annot.InnerColor = Color.Black;
//set the bordercolor 
annot.BorderColor = Color.Green;
//set the textcolor 
annot.TextColor = Color.Yellow;
//set the font 
annot.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
//set overlaytext 
annot.OverlayText = "Redact";
//set text alignment 
annot.TextAlignment = PdfTextAlignment.Right;
//Assign the RepeatText 
annot.RepeatText = true;

//Add the annotation to the page. 
page.Annotations.Add(annot);


// Save the modified document using a new FileStream
using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.Write))
{
    // Save changes to a new PDF file
    document.Save(outputStream);
}
// Close the document and release resources
document.Close(true);