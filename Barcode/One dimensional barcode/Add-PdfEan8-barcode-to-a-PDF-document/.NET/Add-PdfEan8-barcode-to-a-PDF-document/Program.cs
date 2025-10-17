using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Creates a new PdfEan8 Barcode.
PdfEan8Barcode barcode = new PdfEan8Barcode();

//Set height of the barcode.
barcode.BarHeight = 50;

//Set the barcode text.
barcode.Text = "1234567";

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adding new page to PDF document.
    PdfPage page = document.Pages.Add();

    //Printing barcode on to the PDF.
    barcode.Draw(page, new PointF(25, 70));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

