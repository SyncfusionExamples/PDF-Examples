// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using System.Drawing;

//Initialize a new PdfCode39Barcode instance.
PdfQRBarcode qRBarcode = new PdfQRBarcode();

//Set the XDimension and text for barcode.
qRBarcode.XDimension = 3;
qRBarcode.Text = "http://www.google.com";

//Convert the barcode to image.
Image barcodeImage = qRBarcode.ToImage(new System.Drawing.SizeF(300, 300));

//Create memory stream. 
MemoryStream stream = new MemoryStream();

//Save image to stream.
barcodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

//Create file stream.  
FileStream outputFileStream = new FileStream(Path.GetFullPath("../../../BarcodeImage.png"), FileMode.Create, FileAccess.ReadWrite);
outputFileStream.Position = 0;

//Copy memory stream to file stream. 
stream.WriteTo(outputFileStream);

//Dispose the stream. 
stream.Dispose();
outputFileStream.Dispose();
