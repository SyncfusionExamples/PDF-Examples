using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.ColorSpace;
using Syncfusion.Pdf.Functions;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Load the page. 
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

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
    loadedPage.Graphics.DrawRectangle(pen, bounds);

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}