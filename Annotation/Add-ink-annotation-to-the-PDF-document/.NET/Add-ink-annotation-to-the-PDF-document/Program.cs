// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Creates a new PDF document.
PdfDocument document = new PdfDocument();

//Creates a new page.
PdfPage page = document.Pages.Add();

//Create the line points. 
List<float> linePoints = new List<float> { 40, 300, 60, 100, 40, 50, 40, 300 };

RectangleF rectangle = new RectangleF(0, 0, 300, 400);

//Creates a new ink annotation.
PdfInkAnnotation inkAnnotation = new PdfInkAnnotation(rectangle, linePoints);

//Set the color of ink annotation. 
inkAnnotation.Color = new PdfColor(Color.Red);

//Adds annotation to the page.
page.Annotations.Add(inkAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);