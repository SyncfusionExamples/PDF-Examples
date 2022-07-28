// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;

//Creating new PDF Document.
PdfDocument document = new PdfDocument();

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

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
	//Save the PDF document to file stream.
	document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

