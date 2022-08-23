// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the existing form.
PdfLoadedForm loadedForm = loadedDocument.Form;

//Load the FDF file.
FileStream fileStream = new FileStream(Path.GetFullPath("../../../Input.fdf"), FileMode.Open, FileAccess.Read);

//Import the FDF stream.
loadedForm.ImportDataFDF(fileStream, true);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the PDF document. 
loadedDocument.Close(true);