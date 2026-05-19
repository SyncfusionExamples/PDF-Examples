using SkiaSharp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Parsing;

//Load the document
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(@"../../../Input.pdf");

for (int i = 0; i < loadedDocument.Pages.Count; i++)
{
    PdfPageBase loadedPage = loadedDocument.Pages[i];
    
    // 1. Extract text
    string text = loadedPage.ExtractText();

    if (!string.IsNullOrEmpty(text))
    {
        continue; // Page has text, so it's not blank
    }

    // 2. Extract images
    PdfImageInfo[] imagesInfo = loadedPage.GetImagesInfo();

    bool hasNonBlankImage = false;

    foreach (PdfImageInfo imageInfo in imagesInfo)
    {
        using MemoryStream ms = new MemoryStream();
        imageInfo.ImageStream.CopyTo(ms);
        byte[] imageBytes = ms.ToArray();

        if (!IsBlankImage(imageBytes))
        {
            hasNonBlankImage = true;
            break;
        }
    }

    // 3. Final blank-page detection based on image              
    bool hasImages = imagesInfo.Length > 0;

    if (!hasImages || !hasNonBlankImage)
    {
        Console.WriteLine($"Page {i + 1} is blank.");
    }
}

loadedDocument.Close(true);
static bool IsBlankImage(byte[] imageBytes, byte colorTolerance = 5)
{
    using var skData = SKData.CreateCopy(imageBytes);
    using var skImage = SKImage.FromEncodedData(skData);
    using var bitmap = SKBitmap.FromImage(skImage);

    SKColor? referenceColor = null;

    for (int y = 0; y < bitmap.Height; y++)
    {
        for (int x = 0; x < bitmap.Width; x++)
        {
            SKColor pixel = bitmap.GetPixel(x, y);

            if (referenceColor == null)
            {
                referenceColor = pixel;
                continue;
            }

            if (Math.Abs(pixel.Red - referenceColor.Value.Red) > colorTolerance ||
                Math.Abs(pixel.Green - referenceColor.Value.Green) > colorTolerance ||
                Math.Abs(pixel.Blue - referenceColor.Value.Blue) > colorTolerance ||
                Math.Abs(pixel.Alpha - referenceColor.Value.Alpha) > colorTolerance)
            {
                return false; // Not blank
            }
        }
    }

    return true; // Image is blank
}