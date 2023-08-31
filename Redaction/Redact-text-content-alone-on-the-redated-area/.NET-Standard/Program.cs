// See https://aka.ms/new-console-template for more information
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using Syncfusion.Drawing;

FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(docStream);
PdfRedaction redaction = new PdfRedaction(new RectangleF(150, 150, 60, 24), Color.Transparent);
//Only the text within the redaction bounds should be redacted.
redaction.TextOnly = true;
foreach (PdfLoadedPage loadedPage in document.Pages)
{
    loadedPage.AddRedaction(redaction);
}
document.Redact();
//Save the document
MemoryStream stream = new MemoryStream();
document.Save(stream);
File.WriteAllBytes("Output.pdf", stream.ToArray());
//Close the document.
document.Close(true);
