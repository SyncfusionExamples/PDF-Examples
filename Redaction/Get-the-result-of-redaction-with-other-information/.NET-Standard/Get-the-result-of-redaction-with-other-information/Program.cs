// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

//Get stream from an existing PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);

//Load an existing PDF.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the first page.
PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

//Create PDF redaction for the page. 
PdfRedaction redaction = new PdfRedaction(new RectangleF(343, 147, 60, 17), Color.Black);

//Add redaction to the loaded page
page.AddRedaction(redaction);

//Redact the contents from PDF document
List<PdfRedactionResult> redactionResults = loadedDocument.Redact();

foreach (PdfRedactionResult result in redactionResults)
{
    if (result.IsRedactionSuccess)
        Console.WriteLine("Content redacted successfully...");
    else
        Console.WriteLine("Content not redacted properly...");
}

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);

Console.ReadLine();