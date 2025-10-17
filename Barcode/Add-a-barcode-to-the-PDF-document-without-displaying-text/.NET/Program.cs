using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Adding a new page to the PDF document.
    PdfPage page = document.Pages.Add();

    //Create a new instance for the Codabar barcode.
    PdfCode39Barcode barcode = new PdfCode39Barcode();

    //Set the barcode location.
    barcode.Location = new PointF(10, 10);

    //Set the barcode text.
    barcode.Text = "123456789";

    //Disable the barcode text. 
    barcode.TextDisplayLocation = TextLocation.None;

    //Printing barcode on to the PDF document. 
    barcode.Draw(page);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}


