// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.ColorSpace;
using Syncfusion.Pdf.Functions;
using Syncfusion.Pdf.Graphics;

//Creates a new document.
PdfDocument document = new PdfDocument();

//Creates a new page.
PdfPage page = document.Pages.Add();

//Creates exponential interpolation function.
PdfExponentialInterpolationFunction function = new PdfExponentialInterpolationFunction(true);
float[] numberArray = new float[4];
numberArray[0] = 0.38f;
numberArray[1] = 0.88f;
function.C1 = numberArray;

//Creates SeparationColorSpace.
PdfSeparationColorSpace colorSpace = new PdfSeparationColorSpace();
colorSpace.TintTransform = function;
colorSpace.Colorant = "PANTONE Orange 021 C";

//Creates SeparationColorSpace.
PdfSeparationColor color = new PdfSeparationColor(colorSpace);
color.Tint = 0.7;

//Set bounds and pen. 
RectangleF bounds = new RectangleF(20, 70, 200, 100);
PdfPen pen = new PdfPen(color);

//Draws the rectangle.
page.Graphics.DrawRectangle(pen, bounds);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
