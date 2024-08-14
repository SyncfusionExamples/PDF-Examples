// See https://aka.ms/new-console-template for more information

using SkiaSharp;
using Syncfusion.EJ2.PdfViewer;
using System.Drawing;
using System.Drawing.Imaging;

//Uses the Syncfusion.EJ2.PdfViewer assembly.
PdfRenderer pdfExportImage = new PdfRenderer();

//Loads the PDF document.
pdfExportImage.Load(@"..\..\..\Barcode.pdf");

//Exports the PDF document pages into images.
SkiaSharp.SKBitmap[] images = pdfExportImage.ExportAsImage(0, pdfExportImage.PageCount - 1);

for (int i = 0; i < pdfExportImage.PageCount; i++)
{
    //Get the stream from SKBitmap. 
    SkiaSharp.SKData encodeData = images[i].Encode(SkiaSharp.SKEncodedImageFormat.Jpeg, 100);
    Stream imageStream = encodeData.AsStream();

    //Save the SKBitmap as Bitmap. 
    Bitmap bitmapImage = new Bitmap(imageStream);

    bitmapImage.Save(Path.GetFullPath(i.ToString() + ".png"), ImageFormat.Png);

}
