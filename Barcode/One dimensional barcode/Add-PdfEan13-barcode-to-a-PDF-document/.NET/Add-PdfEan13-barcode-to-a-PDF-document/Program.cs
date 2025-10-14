using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Creates a new PdfEan13 Barcode.
PdfEan13Barcode barcode = new PdfEan13Barcode();

//Set height of the barcode.
barcode.BarHeight = 50;

//Set the barcode text.
barcode.Text = "400638133393";

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adding new page to PDF document.
    PdfPage page = document.Pages.Add();

    //Printing barcode on to the PDF document.
    barcode.Draw(page, new PointF(25, 70));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
