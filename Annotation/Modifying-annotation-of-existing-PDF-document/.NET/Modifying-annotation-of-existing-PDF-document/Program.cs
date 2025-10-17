using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets the first page from the document.
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    //Gets the annotation collection.
    PdfLoadedAnnotationCollection annotations = loadedPage.Annotations;

    //Gets the first annotation and modify the properties.
    PdfLoadedPopupAnnotation popUp = annotations[0] as PdfLoadedPopupAnnotation;
    popUp.Border = new PdfAnnotationBorder(4, 0, 0);
    popUp.Color = new PdfColor(Color.Red);
    popUp.Text = "Modified annotation";

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
