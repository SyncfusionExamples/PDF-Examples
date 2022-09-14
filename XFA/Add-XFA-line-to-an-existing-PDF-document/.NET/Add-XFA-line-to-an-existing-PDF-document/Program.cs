// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Load the existing XFA form.
PdfLoadedXfaForm loadedForm = loadedDocument.XfaForm;

//Create a line and add the properties.
PdfXfaLine line = new PdfXfaLine(new PointF(0, 0), new PointF(200, 0), 3);

//Set the line color.
line.Color = new PdfColor(Color.FromArgb(0, 255, 0, 0));

//Add the line to the existing XFA form.
loadedForm.Fields.Add(line);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();
