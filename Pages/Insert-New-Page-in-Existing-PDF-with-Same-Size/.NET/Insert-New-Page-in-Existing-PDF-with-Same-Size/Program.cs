using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

// Load the PDF document from a FileStream
using (FileStream docStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
{
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
    // Get the size of the first page
    PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

    // Insert a new page at the beginning with the same size as the first page
    PdfPageBase page = loadedDocument.Pages.Insert(0, loadedPage.Size);

    // Set the standard font
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
    // Draw the text on the page, centered
    page.Graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

    //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        loadedDocument.Save(outputFileStream);
    }
    // Close the loaded document
    loadedDocument.Close(true);
}