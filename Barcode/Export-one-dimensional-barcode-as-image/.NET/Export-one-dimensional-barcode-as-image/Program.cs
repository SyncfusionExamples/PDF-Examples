// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

//Initialize a new PdfCode39Barcode instance.
PdfCode39Barcode barcode = new PdfCode39Barcode();

//Set the height and text for barcode.
barcode.BarHeight = 45;
barcode.Text = "CODE39$";

// Generate a barcode image with the specified size
Stream barcodeImageStream = barcode.ToImage(new SizeF(300, 200));

// Create a file stream to write the barcode image to a file
FileStream fileStreamResult = new FileStream(Path.GetFullPath(@"Output/BarcodeImage.png"), FileMode.Create, FileAccess.ReadWrite);

// Copy the barcode image data to the file stream
barcodeImageStream.CopyTo(fileStreamResult);

// Ensure all data is written to the file
fileStreamResult.Flush();

// Dispose of the streams to release resources
barcodeImageStream.Dispose();
fileStreamResult.Dispose();

