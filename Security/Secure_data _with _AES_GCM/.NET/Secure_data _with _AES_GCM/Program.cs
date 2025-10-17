using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Set the document version as 2.0
    document.FileStructure.Version = PdfVersion.Version2_0;

    //Add a page to the document. 
    PdfPage page = document.Pages.Add();

    //Create PDF graphics for the page. 
    PdfGraphics graphics = page.Graphics;

    //Set the font. 
    PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 15f, PdfFontStyle.Bold);

    //Set the brush. 
    PdfBrush brush = PdfBrushes.Black;

    //Document security. 
    PdfSecurity security = document.Security;

    //Specifies key size and encryption algorithm. 
    security.KeySize = PdfEncryptionKeySize.Key256Bit;
    security.Algorithm = PdfEncryptionAlgorithm.AESGCM;
    security.OwnerPassword = "ownerPassword";
    security.UserPassword = "userPassword";

    //Draw the text. 
    graphics.DrawString("Encrypted document with AES-GCM 256bit", font, brush, new PointF(0, 40));
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}