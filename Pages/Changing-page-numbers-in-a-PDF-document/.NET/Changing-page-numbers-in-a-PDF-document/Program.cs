using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Create a page label.
    PdfPageLabel pageLabel = new PdfPageLabel();

    //Set the number style with upper case roman letters.
    pageLabel.NumberStyle = PdfNumberStyle.UpperRoman;

    //Set the staring number as 1.
    pageLabel.StartNumber = 1;

    //Set the page label to PDF document. 
    loadedDocument.LoadedPageLabel = pageLabel;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}