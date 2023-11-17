
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;



// Set your AWS credentials and region
string accessKey = "YOUR_ACCESS_KEY";
string secretKey = "YOUR_SECRET_KEY";
RegionEndpoint region = RegionEndpoint.YOUR_REGION; // Change to your desired region

// Specify the bucket name and object key
string bucketName = "YOUR_BUCKET_NAME";
string objectKey = "YOUR_OBJECT_KEY";

string localFilePath = "Output.pdf";
// Download the PDF from S3
//MemoryStream pdfStream = DownloadFromS3(accessKey, secretKey, region, bucketName, objectKey);
using (var s3Client = new AmazonS3Client(accessKey, secretKey, region))
{
    using (var transferUtility = new TransferUtility(s3Client))
    {
        transferUtility.Download(localFilePath, bucketName, objectKey);
    }
}



