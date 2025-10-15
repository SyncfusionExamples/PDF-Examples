using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
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

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}