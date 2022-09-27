// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

foreach (PdfAnnotation annot in loadedDocument.Pages[0].Annotations)
{
    //Check for the Redaction annotation.
    if (annot is PdfLoadedRedactionAnnotation)
    {
        //Load the redaction annotation. 
        PdfLoadedRedactionAnnotation redactAnnot = annot as PdfLoadedRedactionAnnotation;

        //Assign the Bounds values.
        redactAnnot.Bounds = new RectangleF(50, 50, 100, 100);

        //Assign the OverlayText.
        redactAnnot.OverlayText = "Redaction";

        //Assign the InnerColor.
        redactAnnot.InnerColor = Color.Yellow;

        //Assign the BorderColor.
        redactAnnot.BorderColor = Color.Green;

        //Assign the TextColor.
        redactAnnot.TextColor = Color.Red;

        //Assign the TextAlignment.
        redactAnnot.TextAlignment = PdfTextAlignment.Right;

        //Assign the RepeatText.
        redactAnnot.RepeatText = true;

        //Flatten the annotations in the page.
        redactAnnot.Flatten = true;
    }

    loadedDocument.Redact();

    //Save the document.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        loadedDocument.Save(outputFileStream);
    }

    //Close the document.
    loadedDocument.Close(true);
}
