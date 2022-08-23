// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Create a rectangle field and add the properties.  
PdfXfaRectangleField rectangle = new PdfXfaRectangleField("rect1", new SizeF(100, 50));

//Set the fill color.
rectangle.Border.FillColor = new PdfXfaSolidBrush(Color.FromArgb(0, 255, 0, 0));

//Add the rectangle to the existing XFA form.
loadedForm.Fields.Add(rectangle);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();