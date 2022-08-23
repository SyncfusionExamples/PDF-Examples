// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Xfa;

//Create a new PDF XFA document.
PdfXfaDocument document = new PdfXfaDocument();

//Add a new XFA page.
PdfXfaPage xfaPage = document.Pages.Add();

//Create a new PDF XFA form.
PdfXfaForm mainForm = new PdfXfaForm("subform1", xfaPage, xfaPage.GetClientSize().Width);

//Get stream from an image file. 
FileStream imageStream = new FileStream(Path.GetFullPath("../../../image.jpg"), FileMode.Open, FileAccess.Read);

//Create a image and add the properties.
PdfXfaImage image = new PdfXfaImage("image1", imageStream);

//Add the image to the XFA form.
mainForm.Fields.Add(image);

//Add the XFA form to the document.
document.XfaForm = mainForm;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream, PdfXfaType.Dynamic);
}

//Close the document.
document.Close();