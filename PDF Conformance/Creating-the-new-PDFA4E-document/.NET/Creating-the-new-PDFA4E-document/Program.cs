using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new document with the PDF/A-4 standard. 
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A4);

//Creates a new page. 
PdfPage page = document.Pages.Add();

//Get stream from the U3D annotation file.  
FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/design.U3D"), FileMode.Open, FileAccess.Read);

//Create a new pdf 3d annotation. 
Pdf3DAnnotation pdf3dAnnotation = new Pdf3DAnnotation(new RectangleF(10, 50, 300, 150), inputStream);

//Handle the activation of the 3d annotation. 
Pdf3DActivation activation = new Pdf3DActivation();
activation.ActivationMode = Pdf3DActivationMode.ExplicitActivation;
activation.ShowToolbar = true; pdf3dAnnotation.Activation = activation;

//Add the annotation to the page. 
page.Annotations.Add(pdf3dAnnotation);

//Save the PDF document
document.Save(Path.GetFullPath(@"Output/Output.pdf"));

//Close the document.
document.Close(true);