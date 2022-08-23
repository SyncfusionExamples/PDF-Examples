// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Create a new page.
PdfPage page = document.Pages.Add();

//Create a new Redaction annotation.
PdfRedactionAnnotation annot = new PdfRedactionAnnotation();

//Assign the Bounds value.
annot.Bounds = new Rectangle(100, 120, 100, 100);

//Assign the InnerColor.
annot.InnerColor = Color.Black;

//Assign the Bordercolor.
annot.BorderColor = Color.Yellow;

//Assign the Textcolor.
annot.TextColor = Color.Blue;

//Assign the font.
annot.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);

//Assign the OverlayText.
annot.OverlayText = "REDACTION";

//Assign the TextAlignment.
annot.TextAlignment = PdfTextAlignment.Right;

//Assign the RepeatText.
annot.RepeatText = true;
annot.SetAppearance(true);

//Add the annotation to the page.
page.Annotations.Add(annot);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
