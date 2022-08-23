// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Gets the first page from the document.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Gets the annotation collection.
PdfLoadedAnnotationCollection annotations = loadedPage.Annotations;

//Gets the first annotation and modify the properties.
PdfLoadedPopupAnnotation popUp = annotations[0] as PdfLoadedPopupAnnotation;
popUp.Border = new PdfAnnotationBorder(4, 0, 0);
popUp.Color = new PdfColor(Color.Red);
popUp.Text = "Modified annotation";

//Save the document.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
