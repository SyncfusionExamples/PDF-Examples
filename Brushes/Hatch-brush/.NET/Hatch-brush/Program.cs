using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document 
PdfDocument document = new PdfDocument();
//Add a page to the document 
PdfPage page = document.Pages.Add();
//Create PDF graphics for the page 
PdfGraphics graphics = page.Graphics;
//Define colors for the hatch brush 
Color systemForeColor = Color.FromArgb(255, 255, 255, 0);
Color systemBackColor = Color.FromArgb(255, 78, 167, 46);

// Create a new PDF hatch brush with a pattern and colors 
PdfHatchBrush pdfHatchBrush = new PdfHatchBrush(PdfHatchStyle.Plaid, new PdfColor(systemForeColor), new PdfColor(systemBackColor));

//Draw rectangle on the page 
graphics.DrawRectangle(PdfPens.Black, pdfHatchBrush, new Rectangle(100, 100, 300, 200));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);