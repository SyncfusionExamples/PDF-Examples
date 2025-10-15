using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Creates a new page.
    PdfPage page = document.Pages.Add();

    //Get stream from the U3D annotation. 
    FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/design.u3d"), FileMode.Open, FileAccess.Read);

    //Creates a new PDF 3D annotation.
    Pdf3DAnnotation pdf3dAnnotation = new Pdf3DAnnotation(new RectangleF(10, 50, 300, 150), inputStream);

    //Assign JavaScript script.
    pdf3dAnnotation.OnInstantiate = "host.getURL(\"http://www.google.com\")";

    //Handles the activation of the 3D annotation.
    Pdf3DActivation activation = new Pdf3DActivation();
    activation.ActivationMode = Pdf3DActivationMode.ExplicitActivation;
    activation.ShowToolbar = true;
    pdf3dAnnotation.Activation = activation;

    //Adds annotation to page.
    page.Annotations.Add(pdf3dAnnotation);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}