// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Creates a new PDF document.
PdfDocument document = new PdfDocument();

//Creates a new page.
PdfPage page = document.Pages.Add();

//Get stream from the U3D file. 
FileStream inputStream = new FileStream(Path.GetFullPath("../../../threeLevelHierarchy.u3d"), FileMode.Open, FileAccess.Read);

//Creates a new pdf 3d annotation.
Pdf3DAnnotation pdf3dAnnotation = new Pdf3DAnnotation(new RectangleF(10, 50, 300, 150), inputStream);

//Handles the activation of the 3d annotation.
Pdf3DActivation activation = new Pdf3DActivation();
activation.ActivationMode = Pdf3DActivationMode.ExplicitActivation;
activation.ShowToolbar = true;
pdf3dAnnotation.Activation = activation;

//Adds annotation to page
page.Annotations.Add(pdf3dAnnotation);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
