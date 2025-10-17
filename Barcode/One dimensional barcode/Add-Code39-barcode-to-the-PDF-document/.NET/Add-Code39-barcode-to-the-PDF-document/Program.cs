using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adding new page to PDF document.
    PdfPage page = document.Pages.Add();

    //Drawing Code39 barcode.
    PdfCode39Barcode barcode = new PdfCode39Barcode();

    //Setting height of the barcode.
    barcode.BarHeight = 45;

    //Set barcode text. 
    barcode.Text = "CODE39$";

    //Printing barcode on to the Pdf. 
    barcode.Draw(page, new PointF(25, 70));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
