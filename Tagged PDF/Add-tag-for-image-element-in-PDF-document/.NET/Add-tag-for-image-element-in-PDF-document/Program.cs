﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Creates new PDF document.
PdfDocument document = new PdfDocument();

//Set the document title.
document.DocumentInformation.Title = "Image";

//Creates new page.
PdfPage page = document.Pages.Add();

//Load the TrueType font from the local *.ttf file.
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/Arial.ttf"), FileMode.Open, FileAccess.Read);
PdfFont font = new PdfTrueTypeFont(fontStream, 14);

//Draw string.
page.Graphics.DrawString("JPEG Image:", font, PdfBrushes.Blue, new PointF(0, 0));

//Load the image as stream.
FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/pdf.jpg"), FileMode.Open, FileAccess.Read);

//Create a new PDF bitmap object
PdfBitmap bitmap = new PdfBitmap(imageStream);

//Set the tag type
PdfStructureElement imageElement = new PdfStructureElement(PdfTagType.Figure);

//Set the alternate text
imageElement.AlternateText = "GreenTree";

//adding tag to the PDF image
bitmap.PdfTag = imageElement;

//Draw image
bitmap.Draw(page.Graphics, new PointF(50,20));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
fontStream.Dispose();