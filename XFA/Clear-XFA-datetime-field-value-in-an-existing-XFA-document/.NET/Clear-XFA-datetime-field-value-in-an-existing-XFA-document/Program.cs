// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Xfa;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);

//Load the existing XFA document.
PdfLoadedXfaDocument loadedDocument = new PdfLoadedXfaDocument(docStream);

//Get the date time field.
PdfLoadedXfaDateTimeField dateTimeField = loadedDocument.XfaForm.TryGetFieldByCompleteName("form1[0].subform1[0].date[0]") as PdfLoadedXfaDateTimeField;

//Clear the date time field value.
dateTimeField.ClearValue();

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close();
