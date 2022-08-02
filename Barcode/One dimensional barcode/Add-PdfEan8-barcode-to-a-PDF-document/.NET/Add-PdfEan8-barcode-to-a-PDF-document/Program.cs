// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Creates a new PdfEan8 Barcode.
PdfEan8Barcode barcode = new PdfEan8Barcode();

//Set height of the barcode.
barcode.BarHeight = 50;

//Set the barcode text.
barcode.Text = "1234567";

//Creating new PDF document.
PdfDocument document = new PdfDocument();

//Adding new page to PDF document.
PdfPage page = document.Pages.Add();

//Printing barcode on to the PDF.
barcode.Draw(page, new PointF(25, 70));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

