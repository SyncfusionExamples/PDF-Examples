// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Creates a new PdfEan13 Barcode.
PdfEan13Barcode barcode = new PdfEan13Barcode();

//Set height of the barcode.
barcode.BarHeight = 50;

//Set the barcode text.
barcode.Text = "400638133393";

//Creating new PDF document.
PdfDocument document = new PdfDocument();

//Adding new page to PDF document.
PdfPage page = document.Pages.Add();

//Printing barcode on to the PDF document.
barcode.Draw(page, new PointF(25, 70));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
