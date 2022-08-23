// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document. 
PdfDocument document = new PdfDocument();

//Create a new page.
PdfPage page = document.Pages.Add();

//Create points.
int[] points = new int[] { 100, 300, 150, 200, 300, 200, 350, 300, 300, 400, 150, 400 };

//Create a new polygon annotation.
PdfPolygonAnnotation annotation = new PdfPolygonAnnotation(points, "polygon");

//Assign the borderWidth value.
annotation.Border.BorderWidth = 1;

//Assign the color.
annotation.Color = Color.Red;

//Assign the InnerColor.
annotation.InnerColor = Color.Blue;

//Create a new PdfBorderEffect class.
PdfBorderEffect bordereffect = new PdfBorderEffect();

//Assign the intensity value.
bordereffect.Intensity = 2;

//Assign the cloud style.
bordereffect.Style = PdfBorderEffectStyle.Cloudy;

//Assign the BorderEffect.
annotation.BorderEffect = bordereffect;

//Add the annotation to the page.
page.Annotations.Add(annotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

