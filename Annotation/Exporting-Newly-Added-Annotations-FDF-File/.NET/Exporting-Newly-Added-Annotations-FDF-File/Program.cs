
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document from a file stream
using (FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
using (PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(docStream))
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
    pdfLoadedDocument.Pages[0].Annotations.Add(freeText);

    //Export annotations to the FDF format and save to a file using a file stream
    using (FileStream fdfFileStream = new FileStream(Path.GetFullPath(@"Output/Output.fdf"), FileMode.Create, FileAccess.Write))
    {
        pdfLoadedDocument.ExportAnnotations(fdfFileStream, AnnotationDataFormat.Fdf);
    }
}