// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Creates a rectangle.
RectangleF rectangle = new RectangleF(10, 40, 30, 30);

//Creates a new popup annotation.
PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(rectangle, "Test popup annotation");
popupAnnotation.Border.Width = 4;
popupAnnotation.Border.HorizontalRadius = 20;
popupAnnotation.Border.VerticalRadius = 30;

//Sets the pdf popup icon.
popupAnnotation.Icon = PdfPopupIcon.NewParagraph;

//Adds the annotation to loaded page.
loadedDocument.Pages[0].Annotations.Add(popupAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);