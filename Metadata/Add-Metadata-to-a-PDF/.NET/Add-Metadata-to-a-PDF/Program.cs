using System;
using Syncfusion.Pdf;

//Create a PDF document.
using (PdfDocument pdfDoc = new PdfDocument())
{
    pdfDoc.Pages.Add();

    //Set the document information.
    pdfDoc.DocumentInformation.Author = "Syncfusion";
    pdfDoc.DocumentInformation.Title = "Working with PDF Metadata";
    pdfDoc.DocumentInformation.Subject = "PDF metadata overview";
    pdfDoc.DocumentInformation.Keywords = "PDF, metadata, XMP";
    pdfDoc.DocumentInformation.Creator = "Syncfusion .NET PDF library";
    pdfDoc.DocumentInformation.Producer = "Syncfusion .NET PDF library";
    pdfDoc.DocumentInformation.CreationDate = DateTime.Now;
    pdfDoc.DocumentInformation.ModificationDate = DateTime.Now;
    //Save the document.
    pdfDoc.Save(Path.GetFullPath(@"Output/Output.pdf"));
}