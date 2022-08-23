// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create new PDF document.
PdfDocument document = new PdfDocument();

//Create a new PDF page.
PdfPage page = document.Pages.Add();

//Creates a new rectangle.
RectangleF rectangle = new RectangleF(10, 40, 30, 30);

//Creates a new popup annotation with some properties.
PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(rectangle, "Test popup annotation");
popupAnnotation.Border.Width = 4;
popupAnnotation.Border.HorizontalRadius = 20;
popupAnnotation.Border.VerticalRadius = 30;

//Sets the PDF popup icon.
popupAnnotation.Icon = PdfPopupIcon.NewParagraph;

//Adds this annotation to a new page.
page.Annotations.Add(popupAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

