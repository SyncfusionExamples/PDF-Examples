using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Gets the first layer from the layer collection.
    PdfLayer layer = loadedDocument.Layers[0];

    //Disable the visibility.
    layer.Visible = false;

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

