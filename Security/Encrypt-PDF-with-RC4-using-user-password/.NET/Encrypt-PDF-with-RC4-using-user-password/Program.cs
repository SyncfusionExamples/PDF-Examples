// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add page to the document. 
PdfPage page = document.Pages.Add();

//Create PDF graphics for the page. 
PdfGraphics graphics = page.Graphics;

//Set the font. 
PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20f, PdfFontStyle.Bold);

//Set the brush. 
PdfBrush brush = PdfBrushes.Black;

//Document security.
PdfSecurity security = document.Security;

//Specifies key size and encryption algorithm.
security.KeySize = PdfEncryptionKeySize.Key128Bit;
security.Algorithm = PdfEncryptionAlgorithm.RC4;
security.UserPassword = "password";

//Draw the text. 
graphics.DrawString("Encrypted with RC4 128bit", font, brush, new PointF(0, 40));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);