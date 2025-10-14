using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the first page of the loaded PDF document
    PdfPageBase page = loadedDocument.Pages[0];

    //Create line collection. 
    TextLineCollection lineCollection = new TextLineCollection();

    //Extract text from the first page
    string extractedText = page.ExtractText(out lineCollection);

    //Gets each line from the collection
    foreach (var line in lineCollection.TextLine)
    {

        //Gets bounds of the line
        RectangleF lineBounds = line.Bounds;

        // Gets text in the line
        string text = line.Text;
    }

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}