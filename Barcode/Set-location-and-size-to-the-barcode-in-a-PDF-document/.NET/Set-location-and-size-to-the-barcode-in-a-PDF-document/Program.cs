// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Creating new PDF Document.
PdfDocument document = new PdfDocument();

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);