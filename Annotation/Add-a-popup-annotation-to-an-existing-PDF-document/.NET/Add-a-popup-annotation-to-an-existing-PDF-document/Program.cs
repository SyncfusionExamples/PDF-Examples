using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{

    //Get the first page of the PDF document
    PdfPageBase loadedPage = loadedDocument.Pages[0];
    //Create a new popup annotation
    PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(new RectangleF(100, 100, 20, 20), "Comment");
    //Set the icon for the popup annotation
    popupAnnotation.Icon = PdfPopupIcon.Comment;
    //Set the color for the popup annotation
    popupAnnotation.Color = new PdfColor(Color.Yellow);
    //Add the annotation to the page
    loadedPage.Annotations.Add(popupAnnotation);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
