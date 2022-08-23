// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Creates a new PDF document.
PdfDocument document = new PdfDocument();

//Creates a new page.
PdfPage page = document.Pages.Add();

//Creates a new rectangle.
RectangleF rectangle = new RectangleF(10, 40, 30, 30);

//Creates a new Uri Annotation.
PdfUriAnnotation uriAnnotation = new PdfUriAnnotation(rectangle, "http://www.google.com");

//Sets Text to uriAnnotation.
uriAnnotation.Text = "Uri Annotation";

//Adds this annotation to a new page.
page.Annotations.Add(uriAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

