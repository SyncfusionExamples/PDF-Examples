// See https://aka.ms/new-console-template for more information

using Syncfusion.EJ2.PdfViewer;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection.Metadata;

//Uses the Syncfusion.EJ2.PdfViewer assembly.
PdfRenderer pdfExportImage = new PdfRenderer();

//Loads an existing PDF document.
pdfExportImage.Load(Path.GetFullPath("../../../Barcode.pdf"));

//Exports the PDF document pages into images.
SkiaSharp.SKBitmap sKBitmap = pdfExportImage.ExportAsImage(0);

//Get the stream from SKBitmap. 
SkiaSharp.SKData encodeData = sKBitmap.Encode(SkiaSharp.SKEncodedImageFormat.Jpeg, 100);
Stream imageStream = encodeData.AsStream();

//Save the SKBitmap as Bitmap. 
Bitmap bitmapImage = new Bitmap(imageStream);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.jpg"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the exported image file in disk. 
    bitmapImage.Save(outputFileStream, ImageFormat.Jpeg);
}
