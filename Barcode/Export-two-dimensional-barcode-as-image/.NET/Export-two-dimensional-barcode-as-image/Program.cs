using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

//Initialize a new PdfCode39Barcode instance.
PdfQRBarcode qRBarcode = new PdfQRBarcode();

//Set the XDimension and text for barcode.
qRBarcode.XDimension = 3;
qRBarcode.Text = "http://www.google.com";

// Generate a barcode image with the specified size
Stream barcodeImageStream = qRBarcode.ToImage(new SizeF(300, 300));

// Create a file stream to write the barcode image to a file
FileStream fileStreamResult = new FileStream(Path.GetFullPath(@"Output/BarcodeImage.png"), FileMode.Create, FileAccess.ReadWrite);

// Copy the barcode image data to the file stream
barcodeImageStream.CopyTo(fileStreamResult);

// Ensure all data is written to the file
fileStreamResult.Flush();

// Dispose of the streams to release resources
barcodeImageStream.Dispose();
fileStreamResult.Dispose();
