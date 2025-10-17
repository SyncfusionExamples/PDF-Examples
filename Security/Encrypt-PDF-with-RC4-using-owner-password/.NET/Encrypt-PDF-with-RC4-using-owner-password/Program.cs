using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{

    //Add page to the document.
    PdfPage page = document.Pages.Add();

    //Create PDF graphics to the document. 
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
    security.OwnerPassword = "syncfusion";

    //It allows printing and accessibility copy content.
    security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.AccessibilityCopyContent;
    security.UserPassword = "password";
    graphics.DrawString("This document is protected with owner password", font, brush, new PointF(0, 40));
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}