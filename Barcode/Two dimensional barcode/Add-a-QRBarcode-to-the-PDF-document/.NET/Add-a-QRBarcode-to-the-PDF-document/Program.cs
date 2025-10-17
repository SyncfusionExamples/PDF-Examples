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

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adding new page to PDF document.
    PdfPage page = document.Pages.Add();

    //Printing barcode on to the Pdf. 
    barcode.Draw(page, new PointF(25, 70));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
