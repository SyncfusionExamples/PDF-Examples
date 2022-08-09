// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Creates new PDF document.
PdfDocument document = new PdfDocument();

//Set the document title.
document.DocumentInformation.Title = "LineShape";

//Add new page.
PdfPage page = document.Pages.Add();

//Initialize the structure element with tag type as annotation.
PdfStructureElement structureElement = new PdfStructureElement(PdfTagType.Annotation);

//Add alternate text for structure element
structureElement.AlternateText = "Popup Annotation";

//Set the bounds. 
RectangleF rectangle = new RectangleF(10, 40, 30, 30);

//Create the popup annotation.
PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(rectangle, "Test popup annotation");

//Adding tag for the annotation.
popupAnnotation.PdfTag = structureElement;

//Set proerties for popup annotation. 
popupAnnotation.Border.Width = 4;
popupAnnotation.Border.HorizontalRadius = 20;
popupAnnotation.Border.VerticalRadius = 30;

//Sets the PDF pop-up icon
popupAnnotation.Icon = PdfPopupIcon.NewParagraph;

//Adds this annotation to a new page
page.Annotations.Add(popupAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);