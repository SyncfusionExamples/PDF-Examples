using System;
using System.IO;
using System.Threading.Tasks;
using Syncfusion.OCRProcessor;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Amazon;
using Amazon.Textract;
using Amazon.Textract.Model;


namespace OCR.Test
{
    class AWSExternalOcrEngine : IOcrEngine
    {
        private string awsAccessKeyId = "AccessKeyID";
        private string awsSecretAccessKey = "SecretAccessKey";
        private float imageHeight;
        private float imageWidth;
        public OCRLayoutResult PerformOCR(Stream stream)
        {
            AmazonTextractClient clientText = Authenticate();
            DetectDocumentTextResponse textResponse = GetAWSTextractResult(clientText, stream).Result;         
            OCRLayoutResult oCRLayoutResult = ConvertAWSTextractResultToOcrLayoutResult(textResponse);
            return oCRLayoutResult;
        }

        public AmazonTextractClient Authenticate()
        {
            AmazonTextractClient client = new AmazonTextractClient(awsAccessKeyId, awsSecretAccessKey, RegionEndpoint.USEast1);
            return client;
        }
        
        public async Task<DetectDocumentTextResponse> GetAWSTextractResult(AmazonTextractClient client, Stream stream)
        {
            stream.Position = 0;
            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            PdfBitmap bitmap = new PdfBitmap(memoryStream);
            imageHeight = bitmap.Height;
            imageWidth = bitmap.Width;

            DetectDocumentTextResponse response = await client.DetectDocumentTextAsync(new DetectDocumentTextRequest
            {
                Document = new Document
                {
                    Bytes = memoryStream
                }
            });
            return response;
        }
        
        public OCRLayoutResult ConvertAWSTextractResultToOcrLayoutResult(DetectDocumentTextResponse textResponse)
        {
            OCRLayoutResult layoutResult = new OCRLayoutResult();
            Syncfusion.OCRProcessor.Page ocrPage = new Page();
            Syncfusion.OCRProcessor.Line ocrLine;
            Syncfusion.OCRProcessor.Word ocrWord;
            layoutResult.ImageHeight = imageHeight;
            layoutResult.ImageWidth = imageWidth;
            foreach (var page in textResponse.Blocks)
            {                   
                ocrLine = new Line();
                if (page.BlockType == "WORD")
                {
                    ocrWord = new Word();
                    ocrWord.Text = page.Text;
                    
                    float left = page.Geometry.BoundingBox.Left;
                    float top = page.Geometry.BoundingBox.Top;
                    float width = page.Geometry.BoundingBox.Width;
                    float height = page.Geometry.BoundingBox.Height;
                    Rectangle rect = GetBoundingBox(left,top,width,height);
                    ocrWord.Rectangle = rect;
                    ocrLine.Add(ocrWord);
                    ocrPage.Add(ocrLine);
                }               
            }
            layoutResult.Add(ocrPage);
            return layoutResult;
        }
        public Rectangle GetBoundingBox(float left, float top, float width, float height)
        {
            int x = Convert.ToInt32(left * imageWidth);
            int y = Convert.ToInt32(top * imageHeight);
            int bboxWidth = Convert.ToInt32((width * imageWidth) + x);
            int bboxHeight = Convert.ToInt32((height * imageHeight) + y);
            Rectangle rect = new Rectangle(x,y, bboxWidth, bboxHeight);
            return rect;
        }
    }
}
 