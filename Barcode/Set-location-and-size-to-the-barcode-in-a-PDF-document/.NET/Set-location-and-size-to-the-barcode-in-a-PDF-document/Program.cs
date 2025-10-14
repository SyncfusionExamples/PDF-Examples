using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adding new page to PDF document.
    PdfPage page = document.Pages.Add();

    //Create new instance for Codabar barcode.
    PdfCodabarBarcode barcode = new PdfCodabarBarcode();

    //Setting location of the barcode.
    barcode.Location = new PointF(100, 100);

    //Setting size of the barcode.
    barcode.Size = new SizeF(200, 100);
    barcode.Text = "123456789$";

    //Printing barcode on to the PDF document. 
    barcode.Draw(page);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}