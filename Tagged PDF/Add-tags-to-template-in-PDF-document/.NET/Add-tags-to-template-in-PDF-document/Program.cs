﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Creates a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Set document information. 
pdfDocument.DocumentInformation.Title = "TemplateDocument";

//Add a page to the PDF document.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Load the TrueType font from the local *.ttf file.
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/Arial.ttf"), FileMode.Open, FileAccess.Read);
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

//Draw text in page. 
pdfPage.Graphics.DrawString("Rectangle:", font, PdfBrushes.Blue, new PointF(0, 0));

//Create a PDF template.
PdfTemplate template = new PdfTemplate(100, 50);

//Initialize the structure element with tag type figure
PdfStructureElement structureElement = new PdfStructureElement(PdfTagType.Figure);

//Set alternative description for figure
structureElement.AlternateText = "Template Figure";

//Adding tag to the template element
template.PdfTag = structureElement;

//Set the brush. 
PdfBrush brush = new PdfSolidBrush(Color.Pink);

//Draw rectangle using template graphics
template.Graphics.DrawRectangle(brush, new RectangleF(0, 30, 150, 90));

//Draw the template on the page graphics of the document
pdfPage.Graphics.DrawPdfTemplate(template, PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);
fontStream.Dispose();
