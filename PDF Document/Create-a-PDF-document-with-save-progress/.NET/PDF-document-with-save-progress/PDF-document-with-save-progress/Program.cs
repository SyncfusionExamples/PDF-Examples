
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Add new pages to the document.
PdfPage page = document.Pages.Add();
//Create font and font style.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);
//Draw text in the new page.
page.Graphics.DrawString("Essential PDF", font, PdfBrushes.Black, new PointF(10, 10));
document.SaveProgress += new PdfDocument.ProgressEventHandler(document_SaveProgress);


//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
// Event handler for PageAdded event
void document_SaveProgress(object sender, ProgressEventArgs arguments)
{
    Console.WriteLine(String.Format("Current: {0}, Progress: {1}, Total {2}", arguments.Current, arguments.Progress, arguments.Total));
}