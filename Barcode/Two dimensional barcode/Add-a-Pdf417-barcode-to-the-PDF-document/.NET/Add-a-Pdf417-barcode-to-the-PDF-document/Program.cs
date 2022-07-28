// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Creates a new Pdf417 Barcode.
Pdf417Barcode barcode = new Pdf417Barcode();

//Set error correction level.
barcode.ErrorCorrectionLevel = Pdf417ErrorCorrectionLevel.Auto;

//Set XDimension.
barcode.XDimension = 2;

//Set the barcode text.
barcode.Text = "http://www.syncfusion.com";

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


