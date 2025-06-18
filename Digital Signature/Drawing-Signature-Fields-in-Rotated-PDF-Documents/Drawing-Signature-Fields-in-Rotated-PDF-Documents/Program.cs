using Syncfusion.Pdf;
using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

internal class Program
{
    static void Main(string[] args)
    {
        //Open the Word document file stream.
        using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/TestPDF.pdf"), FileMode.Open, FileAccess.Read))
        {

            PdfLoadedDocument pdfLoadedDocument = new PdfLoadedDocument(inputStream);

            PdfLoadedPage ldPage = pdfLoadedDocument.Pages[3] as PdfLoadedPage;

            //Create a certificate instance from a PFX file with a private key.
            FileStream certificateStream = new FileStream(Path.GetFullPath(@"Data/PDF.pfx"), FileMode.Open, FileAccess.Read);
            PdfCertificate pdfCert = new PdfCertificate(certificateStream, "password123");

            PdfSignature signature = new PdfSignature(pdfLoadedDocument, ldPage, pdfCert, "Signature1");

            RectangleF bounds = new RectangleF(new PointF(20, 20), new SizeF(240, 70));


            signature.Bounds = GetRelativeBounds(ldPage, bounds);

            PdfGraphics graphics = signature.Appearance.Normal.Graphics;

            FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/TestImage.png"), FileMode.Open, FileAccess.Read);
            //Set an image for signature field.
            PdfBitmap signatureImage = new PdfBitmap(imageStream);

            RotateSignatureAppearance(signatureImage, signature.Appearance.Normal.Graphics, ldPage.Rotation, signature.Bounds);

            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                //Save the PDF document to file stream.
                pdfLoadedDocument.Save(outputFileStream);
            }
            //Closes the document 
            pdfLoadedDocument.Close(true);

        }
    }
    private static RectangleF GetRelativeBounds(PdfLoadedPage page, RectangleF bounds)
    {
        SizeF pagesize = page.Size;
        RectangleF rectangle = bounds;

        if (page.Rotation == PdfPageRotateAngle.RotateAngle90)
        {
            rectangle.X = bounds.Y;
            rectangle.Y = pagesize.Height - ((bounds.X + bounds.Width));
            rectangle.Width = bounds.Height;
            rectangle.Height = bounds.Width;
        }
        else if (page.Rotation == PdfPageRotateAngle.RotateAngle270)
        {
            rectangle.Y = bounds.X;
            rectangle.X = pagesize.Width - (bounds.Y + bounds.Height);
            rectangle.Width = bounds.Height;
            rectangle.Height = bounds.Width;
        }
        else if (page.Rotation == PdfPageRotateAngle.RotateAngle180)
        {
            rectangle.X = pagesize.Width - (bounds.X + bounds.Width);
            rectangle.Y = pagesize.Height - (bounds.Y + bounds.Height);
        }
        return rectangle;
    }

    private static void RotateSignatureAppearance(PdfImage image, PdfGraphics graphics, PdfPageRotateAngle angle, RectangleF bounds)
    {
        graphics.Save();

        if (angle == PdfPageRotateAngle.RotateAngle90)
        {
            graphics.TranslateTransform(0, bounds.Height);
            graphics.RotateTransform(-90);
            graphics.DrawImage(image, new RectangleF(0, 0, bounds.Height, bounds.Width));
        }
        else if (angle == PdfPageRotateAngle.RotateAngle180)
        {
            graphics.TranslateTransform(bounds.Width, bounds.Height);
            graphics.RotateTransform(-180);
            graphics.DrawImage(image, new RectangleF(0, 0, bounds.Width, bounds.Height));
        }
        else if (angle == PdfPageRotateAngle.RotateAngle270)
        {
            graphics.TranslateTransform(bounds.Width, 0);
            graphics.RotateTransform(-270);
            graphics.DrawImage(image, new RectangleF(0, 0, bounds.Height, bounds.Width));
        }
        else
        {
            graphics.DrawImage(image, new RectangleF(0, 0, bounds.Width, bounds.Height));
        }
        graphics.Restore();
    }

}

