
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;


// Create a new PDF document.
PdfDocument document = new PdfDocument();

// Add multiple pages to the document.
for (int i = 0; i < 10; i++)
{
    // Add a new page.
    PdfPage page = document.Pages.Add();

    // Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    // Set the font to Helvetica with size 20.
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

    // Draw text on the page.
    graphics.DrawString($"This is page {i + 1}", font, PdfBrushes.Black, new PointF(0, 0));
}

// Subscribe to the SaveProgress event.
document.SaveProgress += new PdfDocument.ProgressEventHandler(document_SaveProgress);

// Create a file stream to save the PDF document.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    // Save the PDF document to the file stream.
    document.Save(outputFileStream);
}

// Close the document.
document.Close(true);

// Event handler for the SaveProgress event.
void document_SaveProgress(object sender, ProgressEventArgs arguments)
{
    // Output the current progress of the save operation.
    Console.WriteLine(String.Format("Current: {0}, Progress: {1}, Total: {2}", arguments.Current, arguments.Progress, arguments.Total));
}