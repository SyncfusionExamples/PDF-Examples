// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document. 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the first page of the document.
PdfPageBase page = loadedDocument.Pages[0];

//Create a page template.
PdfPageTemplate pageTemplate = new PdfPageTemplate(page);

//Sets the PdfPageTemplate name.
pageTemplate.Name = "pageTemplate";

//Sets the PdfPageTemplate is visible.
pageTemplate.IsVisible = true;

//Adds the page template.
loadedDocument.PdfPageTemplates.Add(pageTemplate);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);