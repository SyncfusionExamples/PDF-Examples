// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.ColorSpace;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document.
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Loads the page.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

//Acquires graphics of the page.
PdfGraphics graphics = loadedPage.Graphics;

//Creates ICCBased color space.
PdfCalRGBColorSpace calRgbCS = new PdfCalRGBColorSpace();
calRgbCS.Gamma = new double[] { 7.6, 5.1, 8.5 };
calRgbCS.Matrix = new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
calRgbCS.WhitePoint = new double[] { 0.7, 1, 0.8 };

//Reads the ICC profile.
FileStream fileStream = new FileStream(Path.GetFullPath(@"../../../input.icc"), FileMode.Open, FileAccess.Read);
byte[] profileData = new byte[fileStream.Length];
fileStream.Read(profileData, 0, profileData.Length);
fileStream.Close();
    
//Instantiates ICC color space.
PdfICCColorSpace iccBasedCS = new PdfICCColorSpace();
iccBasedCS.ProfileData = profileData;
iccBasedCS.AlternateColorSpace = calRgbCS;
iccBasedCS.ColorComponents = 3;
iccBasedCS.Range = new double[] { 0.0, 1.0, 0.0, 1.0, 0.0, 1.0 };

//Create the ICC color. 
PdfICCColor red = new PdfICCColor(iccBasedCS);
red.ColorComponents = new double[] { 1, 0, 1 };

//Set the brush.
PdfBrush brush = new PdfSolidBrush(red);

//Set the bounds. 
RectangleF bounds = new RectangleF(0, 0, 300, 300);

//Draws rectangle by using the PdfBrush.
graphics.DrawRectangle(brush, bounds);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
