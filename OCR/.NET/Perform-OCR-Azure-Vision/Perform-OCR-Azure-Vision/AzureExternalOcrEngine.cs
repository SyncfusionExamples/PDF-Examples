using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Syncfusion.OCRProcessor;
using Syncfusion.Drawing;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;


namespace OCR.Test
{
    class AzureExternalOcrEngine : IOcrEngine
    {
        private string subscriptionKey = "SubscriptionKey";
        private string endpoint = "Endpoint link";
        public OCRLayoutResult PerformOCR(Stream imgStream)
        {
            ComputerVisionClient client = Authenticate();
            ReadResult azureOcrResult = ReadFileUrl(client, imgStream).Result;               
            OCRLayoutResult result = ConvertAzureVisionOcrToOcrLayoutResult(azureOcrResult);
            return result;
        }

        public ComputerVisionClient Authenticate()
        {
            ComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
            {
                Endpoint = endpoint
            };
            return client;
        }

        public async Task<ReadResult> ReadFileUrl(ComputerVisionClient client, Stream stream)
        {
            stream.Position = 0;
            var textHeaders = await client.ReadInStreamAsync(stream);
            string operationLocation = textHeaders.OperationLocation;
            const int numberOfCharsInOperationId = 36;
            string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);
            
            //Extract the text
            ReadOperationResult results;
            do
            {
                results = await client.GetReadResultAsync(Guid.Parse(operationId));
            }
            while ((results.Status == OperationStatusCodes.Running || results.Status == OperationStatusCodes.NotStarted));

            ReadResult azureOcrResult = results.AnalyzeResult.ReadResults[0];
            return azureOcrResult;
        }
        private OCRLayoutResult ConvertAzureVisionOcrToOcrLayoutResult(ReadResult azureVisionOcr)
        {
            Syncfusion.OCRProcessor.Line ocrLine;
            Syncfusion.OCRProcessor.Word ocrWord;
            
            OCRLayoutResult ocrlayoutResult = new OCRLayoutResult();         
            ocrlayoutResult.ImageWidth = (float)azureVisionOcr.Width;
            ocrlayoutResult.ImageHeight = (float)azureVisionOcr.Height;

            //Page
            Syncfusion.OCRProcessor.Page normalPage = new Syncfusion.OCRProcessor.Page();

            //Lines
            foreach (var line in azureVisionOcr.Lines)
            {
                ocrLine = new Syncfusion.OCRProcessor.Line();

                //Word
                foreach (var word in line.Words)
                {
                    ocrWord = new Syncfusion.OCRProcessor.Word();

                    Rectangle rect = GetAzureVisionBounds(word.BoundingBox);

                    ocrWord.Text = word.Text;
                    ocrWord.Rectangle = rect;

                    ocrLine.Add(ocrWord);
                }
                normalPage.Add(ocrLine);
            }

            ocrlayoutResult.Add(normalPage);
            return ocrlayoutResult;
        }

        private Rectangle GetAzureVisionBounds(IList<double?> bbox)
        {
            Rectangle rect = Rectangle.Empty;
            PointF[] pointCollection = new PointF[bbox.Count / 2];
            int count = 0;
            for (int i = 0; i < bbox.Count; i = i + 2)
            {
                pointCollection[count] = new PointF((float)bbox[i], (float)bbox[i + 1]);
                count++;
            }
            float xMin = 0;
            float yMin = 0;
            float xMax = 0;
            float yMax = 0;
            bool first = true;

            foreach (PointF point in pointCollection)
            {
                if (first)
                {
                    xMin = point.X;
                    yMin = point.Y;
                    first = false;
                }
                else
                {
                    if (point.X < xMin)
                        xMin = point.X;
                    else if (point.X > xMax)
                        xMax = point.X;
                    if (point.Y < yMin)
                        yMin = point.Y;
                    else if (point.Y > yMax)
                        yMax = point.Y;
                }
            }

            int x = Convert.ToInt32(xMin);
            int y = Convert.ToInt32(yMin);
            int w = Convert.ToInt32(xMax);
            int h = Convert.ToInt32(yMax);

            return new Rectangle(x, y, w, h);
        }
    }
}
