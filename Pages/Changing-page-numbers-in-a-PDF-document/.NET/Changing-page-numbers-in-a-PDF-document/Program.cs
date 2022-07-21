// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get file stream from an existing PDF document.
FileStream inputFileStream = new FileStream(Path.GetFullPath(@"../../../Input.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);

//Create a page label.
PdfPageLabel pageLabel = new PdfPageLabel();

//Set the number style with upper case roman letters.
pageLabel.NumberStyle = PdfNumberStyle.UpperRoman;

//Set the staring number as 1.
pageLabel.StartNumber = 1;

//Set the page label to PDF document. 
loadedDocument.LoadedPageLabel = pageLabel;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);