
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Create a PDF free text annotation
    PdfFreeTextAnnotation freeText = new PdfFreeTextAnnotation(new RectangleF(10, 0, 50, 50));

    //Set properties for the annotation
    freeText.MarkupText = "Free Text with Callout"; //Text displayed as markup
    freeText.TextMarkupColor = new PdfColor(Color.Black); //Set the text markup color
    freeText.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 7f); //Set font and size
    freeText.Color = new PdfColor(Color.Yellow); //Set background color
    freeText.BorderColor = new PdfColor(Color.Red); //Set border color
    freeText.Border = new PdfAnnotationBorder(0.5f); //Set border thickness

    //Add the annotation to the first page of the PDF
    loadedDocument.Pages[0].Annotations.Add(freeText);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}