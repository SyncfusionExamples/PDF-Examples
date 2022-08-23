// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Create a new page.
PdfPage page = document.Pages.Add();

//Create new rectangle annotation.
PdfRectangleAnnotation rectangleAnnotation = new PdfRectangleAnnotation(new RectangleF(0, 0, 100, 50), "Rectangle Annotation");

//Set the properties to rectangle annotation.
rectangleAnnotation.Author = "Syncfusion";
rectangleAnnotation.Border.BorderWidth = 1;
rectangleAnnotation.Color = Color.Red;
rectangleAnnotation.ModifiedDate = DateTime.Now;

//Create a new comment annotation.
PdfPopupAnnotation comment = new PdfPopupAnnotation();

//Set author to comment annotation.
comment.Author = "John";

//Set Text to comment annotation.
comment.Text = "This is first comment";

//Set modification date.
comment.ModifiedDate = DateTime.Now;

//Set subject.
comment.Subject = "Annotation Comments";

//Add the comment to the annotation.
rectangleAnnotation.Comments.Add(comment);

//Add the annotation to the PDF page.
page.Annotations.Add(rectangleAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);