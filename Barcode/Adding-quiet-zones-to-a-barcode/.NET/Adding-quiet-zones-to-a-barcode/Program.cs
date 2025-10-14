using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create a new page. 
    PdfPage page = document.Pages.Add();

    // Create barcode with quiet zones
    PdfCode128Barcode barcode = new PdfCode128Barcode
    {
        Text = "SYNCFUSION",
        BarHeight = 40,
        QuietZone = new PdfBarcodeQuietZones
        {
            Left = 15,   // 15 points = ~5.3mm
            Right = 15,
            Top = 8,     // 8 points = ~2.8mm
            Bottom = 8
        }
    };

    //Draw a barcode on the new page.
    barcode.Draw(page, new PointF(10, 10));

    //Draw a rectangle based on the barcode size. 
    page.Graphics.DrawRectangle(PdfPens.Red, new RectangleF(10, 10, barcode.Size.Width, barcode.Size.Height));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}