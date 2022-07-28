// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load the existing PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the first page of the loaded PDF document.
PdfPageBase page = loadedDocument.Pages[0];

//Create the text collection. 
var lineCollection = new TextLineCollection();

// Extract text from the first page.
string extractedText = page.ExtractText(out lineCollection);

// Gets each line from the collection.
foreach (var line in lineCollection.TextLine)
{

    //Gets bounds of the line.
    RectangleF lineBounds = line.Bounds;

    //Gets text in the line.
    string text = line.Text;

    //Gets collection of the words in the line.
    List<TextWord> textWordCollection = line.WordCollection;
}

//Close the document.
loadedDocument.Close(true);