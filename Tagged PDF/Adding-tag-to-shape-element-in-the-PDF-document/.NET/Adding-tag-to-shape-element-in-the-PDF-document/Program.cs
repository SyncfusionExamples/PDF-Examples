﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Creates new PDF document.
PdfDocument document = new PdfDocument();

//Set the document title.
document.DocumentInformation.Title = "LineShape";

//Add new page.
PdfPage page = document.Pages.Add();

//Load the TrueType font from the local *.ttf file.
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/Arial.ttf"), FileMode.Open, FileAccess.Read);
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

//Draw text.
page.Graphics.DrawString("Line Shape:", font, PdfBrushes.Blue, new PointF(30, 80));

//Initialize structure element with tag type as figure.
PdfStructureElement element = new PdfStructureElement(PdfTagType.Figure);

//Set alternate text.
element.AlternateText = "Line Sample";

//Initialize the line shape.
PdfLine line = new PdfLine(100, 100, 100, 300);

line.Pen = new PdfPen(Color.Red);

//Adding tag to the line element.
line.PdfTag = element;

//Draws the line.
line.Draw(page.Graphics);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
fontStream.Dispose();


