// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Drawing QR Barcode.
PdfQRBarcode barcode = new PdfQRBarcode();

//Set Error Correction Level.
barcode.ErrorCorrectionLevel = PdfErrorCorrectionLevel.High;

//Set XDimension.
barcode.XDimension = 3;

//Set the barcode text. 
barcode.Text = "http://www.syncfusion.com";

//Creating a new PDF Document.
PdfDocument document = new PdfDocument();

//Adding new page to PDF document.
PdfPage page = document.Pages.Add();

//Printing barcode on to the Pdf. 
barcode.Draw(page, new PointF(25, 70));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
