using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using SkiaSharp;
using Syncfusion.OCRProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_ImageEnhancement
{
    class ImageProcessor : IImageProcessor
    {
        public Stream ProcessImage(Stream imageStream)
        {
            //Process the image from stream with any third party library and return the processed image.
            Stream processedImageStream = ConvertToGrayscaleImage(imageStream);
            return processedImageStream;
        }
       
        public Stream EnhanceResolution(Stream imgstream)
        {
            var imageStream = new MemoryStream();
            imgstream.CopyTo(imageStream);
            SKBitmap bitmap = SKBitmap.Decode(imageStream.ToArray());

            // Create a new SKImageInfo with the same width and height as the original image
            SKImageInfo info = new SKImageInfo(bitmap.Width, bitmap.Height);

            // Create a new SKSurface with the SKImageInfo
            using (SKSurface surface = SKSurface.Create(info))
            {
                // Get the SKCanvas from the SKSurface
                SKCanvas canvas = surface.Canvas;

                // Create a new SKPaint for drawing
                SKPaint paint = new SKPaint();

                // Create a sharpening factor (experiment with different values)
                float sharpenFactor = 12;

                // Loop through each pixel and apply sharpening
                for (int x = 1; x < bitmap.Width - 1; x++)
                {
                    for (int y = 1; y < bitmap.Height - 1; y++)
                    {
                        // Get the pixel values from the surrounding pixels
                        SKColor center = bitmap.GetPixel(x, y);
                        SKColor left = bitmap.GetPixel(x - 1, y);
                        SKColor right = bitmap.GetPixel(x + 1, y);
                        SKColor top = bitmap.GetPixel(x, y - 1);
                        SKColor bottom = bitmap.GetPixel(x, y + 1);

                        // Calculate the sharpened pixel value
                        byte red = Clamp((int)(center.Red + sharpenFactor * (center.Red - (left.Red + right.Red + top.Red + bottom.Red) / 4)));
                        byte green = Clamp((int)(center.Green + sharpenFactor * (center.Green - (left.Green + right.Green + top.Green + bottom.Green) / 4)));
                        byte blue = Clamp((int)(center.Blue + sharpenFactor * (center.Blue - (left.Blue + right.Blue + top.Blue + bottom.Blue) / 4)));

                        // Apply the sharpened pixel value
                        SKColor sharpenedColor = new SKColor(red, green, blue);
                        paint.Color = sharpenedColor;

                        // Draw a rectangle representing the sharpened pixel
                        canvas.DrawRect(x, y, 1, 1, paint);
                    }
                }

                // Create a new SKImage from the SKSurface
                SKImage image = surface.Snapshot();

                // Encode the SKImage to a new SKData
                SKData data = image.Encode(SKEncodedImageFormat.Png, 100);
                using (var stream1 = System.IO.File.OpenWrite("sharpened1.png"))
                {
                    data.SaveTo(stream1);
                    //  stream.Dispose();
                }
                return data.AsStream();
            }
        }
        static byte Clamp(int value)
        {
            return (byte)(value < 0 ? 0 : (value > 255 ? 255 : value));
        }
        private Stream ConvertToGrayscaleImage(Stream imgstream)
        {
            var imageStream = new MemoryStream();
            imgstream.CopyTo(imageStream);
            SKBitmap originalBitmap = SKBitmap.Decode(imageStream.ToArray());
            // Create a new bitmap with the same dimensions as the original
            SKBitmap grayscaleBitmap = new SKBitmap(originalBitmap.Width, originalBitmap.Height);

            // Iterate through each pixel in the original bitmap
            for (int x = 0; x < originalBitmap.Width; x++)
            {
                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    // Get the color of the original pixel
                    SKColor originalColor = originalBitmap.GetPixel(x, y);

                    // Calculate the grayscale value
                    byte grayscaleValue = (byte)((originalColor.Red + originalColor.Green + originalColor.Blue) / 3);

                    // Create a new color with the same grayscale value for all channels
                    SKColor grayscaleColor = new SKColor(grayscaleValue, grayscaleValue, grayscaleValue);

                    // Set the pixel in the new grayscale bitmap
                    grayscaleBitmap.SetPixel(x, y, grayscaleColor);
                }
            }

            // Save or use the grayscale image as needed
            SKImage grayscaleImage = SKImage.FromBitmap(grayscaleBitmap);

            // Encode and save the image
            SKData data = grayscaleImage.Encode();
            return data.AsStream();
        }
        private Stream Sixlaborslib(Stream imageStream)
        {
            MemoryStream stream = new MemoryStream();
            using (Image image = Image.Load(imageStream))
            {
                image.Mutate(x => x.GaussianSharpen());
                image.Mutate(x => x.Grayscale());
                image.Mutate(x => x.BinaryThreshold(0.75f));
                image.Save(stream, new PngEncoder());
            }
            return stream;
        }
        private Stream imageBinarization(Stream imgstream)
        {
            var imageStream = new MemoryStream();
            imgstream.CopyTo(imageStream);
            SKBitmap bitmap = SKBitmap.Decode(imageStream.ToArray());

            // Create a new SKImageInfo with the same width and height as the original image
            SKImageInfo info = new SKImageInfo(bitmap.Width, bitmap.Height);

            // Create a new SKSurface with the SKImageInfo
            using (SKSurface surface = SKSurface.Create(info))
            {
                // Get the SKCanvas from the SKSurface
                SKCanvas canvas = surface.Canvas;

                // Create a new SKPaint for drawing
                SKPaint paint = new SKPaint();

                // Loop through each pixel and apply binarization based on a threshold
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        SKColor pixelColor = bitmap.GetPixel(x, y);

                        // Adjust the threshold value based on your needs
                        int threshold = 205;

                        // Perform binarization
                        SKColor binarizedColor = (pixelColor.Red + pixelColor.Green + pixelColor.Blue) / 3 > threshold
                            ? SKColors.White
                            : SKColors.Black;

                        paint.Color = binarizedColor;

                        // Draw a rectangle representing the binarized pixel
                        canvas.DrawRect(x, y, 1, 1, paint);
                    }
                }

                // Create a new SKImage from the SKSurface
                SKImage image = surface.Snapshot();

                // Encode the SKImage to a new SKData
                SKData data = image.Encode(SKEncodedImageFormat.Png, 100);

                return data.AsStream();

            }
        }
    }
}
