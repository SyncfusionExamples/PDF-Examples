// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Create a circle field and add the properties.
PdfXfaCircleField circle = new PdfXfaCircleField("circle", new SizeF(100, 100));

//Set the fill color.
circle.Border.FillColor = new PdfXfaSolidBrush(Color.FromArgb(0, 255, 0, 0));

//Add the circle to the existing XFA form.
loadedForm.Fields.Add(circle);

//Save the document.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();
