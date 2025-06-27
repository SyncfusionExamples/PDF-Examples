using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document. 
PdfDocument document = new PdfDocument();
//Add a page to the document. 
PdfPage page = document.Pages.Add();

//Create a new Redaction annotation 
PdfRedactionAnnotation annot = new PdfRedactionAnnotation();
//Assign the Bounds Value 
annot.Bounds = new Rectangle(100, 120, 100, 100);
//Assign the InnerColor 
annot.InnerColor = Color.Black;
//Assign the BorderColor 
annot.BorderColor = Color.Yellow;

//Assign the AppearanceFillColor 
annot.AppearanceFillColor = Color.BlueViolet;

//Assign tbe TextColor 
annot.TextColor = Color.Blue;
//Assign the font 
annot.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
//Assign the OverlayText 
annot.OverlayText = "REDACTION";
//Assign the TextAlignment 
annot.TextAlignment = PdfTextAlignment.Right;
//Assign the RepeatText 
annot.RepeatText = true;
annot.SetAppearance(true);

//Add the annotation to the page 
page.Annotations.Add(annot);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);