
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Amazon.S3;
using Syncfusion.Drawing;
using Amazon.S3.Transfer;
using Amazon;

using (PdfDocument document = new PdfDocument())
{
    // Add a page to the document
    PdfPage page = document.Pages.Add();

    // Create a PDF graphics for the page
    PdfGraphics graphics = page.Graphics;

    // Draw text on the page
    graphics.DrawString("Hello, Syncfusion PDF!", new PdfStandardFont(PdfFontFamily.Helvetica, 12), PdfBrushes.Black, new PointF(10, 10));

    // Save the PDF document
    document.Save("HelloWorld.pdf");

    // Upload the PDF to AWS S3 (see next step)

    // Set your AWS credentials and region
    string accessKey = "YOUR_ACCESS_KEY";
    string secretKey = "YOUR_SECRET_KEY";
    RegionEndpoint region = RegionEndpoint.YOUR_REGION; // Change to your desired region

    // Create an Amazon S3 client
    using (var s3Client = new AmazonS3Client(accessKey, secretKey, region))
    {
        // Specify the bucket name and object key
        string bucketName = "yOUR_BUCKET_NAME";
        string objectKey = "HelloWorld.pdf";

        // Upload the PDF to S3
        using (var transferUtility = new TransferUtility(s3Client))
        {
            transferUtility.Upload(stream, bucketName, objectKey);
        }
    }
}


