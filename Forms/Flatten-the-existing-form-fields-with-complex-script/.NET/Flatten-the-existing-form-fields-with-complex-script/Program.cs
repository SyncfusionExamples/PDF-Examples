// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using System.Reflection.Metadata;

//Get stream from an existing PDF document. 
FileStream inputFileStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);

//Get the existing PDF form.
PdfLoadedForm lForm = loadedDocument.Form as PdfLoadedForm;

//Set the complex script layout.
lForm.ComplexScript = true;

//Set flatten.
lForm.Flatten = true;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);


