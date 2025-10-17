﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
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
    }
    loadedDocument.Redact();

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

