using Omr.Engine;
using Omr.Engine.Geometry;
using SkiaSharp;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;

namespace Omr.Poc;

public sealed class ZXingBarcodeDecoder : IBarcodeDecoder
{
    public string? Decode(SKBitmap page, PixelRect? crop)
    {
        using SKBitmap target = Crop(page, crop);
        byte[] rgb = ToRgb(target);
        RGBLuminanceSource source = new(rgb, target.Width, target.Height);
        BarcodeReaderGeneric reader = new()
        {
            AutoRotate = true,
            Options = new DecodingOptions
            {
                PossibleFormats = [BarcodeFormat.QR_CODE],
                TryHarder = true,
                PureBarcode = false
            }
        };

        Result? result = reader.Decode(source);
        return result?.Text;
    }

    public static SKBitmap EncodeQr(string payload, int width, int height)
    {
        BarcodeWriterPixelData writer = new()
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Width = Math.Max(32, width),
                Height = Math.Max(32, height),
                Margin = 1,
                CharacterSet = "UTF-8"
            }
        };

        PixelData data = writer.Write(payload);
        SKBitmap bitmap = new(data.Width, data.Height, SKColorType.Bgra8888, SKAlphaType.Opaque);
        IntPtr dest = bitmap.GetPixels();
        if (dest == IntPtr.Zero)
        {
            throw new InvalidOperationException("QR bitmap has no pixel buffer.");
        }

        unsafe
        {
            byte* d = (byte*)dest.ToPointer();
            byte[] pixels = data.Pixels;
            int n = data.Width * data.Height;
            int srcStride = pixels.Length >= n * 4 ? 4 : 3;
            for (int i = 0; i < n; i++)
            {
                int s = i * srcStride;
                int p = i * 4;
                if (srcStride == 4)
                {
                    d[p] = pixels[s + 2];
                    d[p + 1] = pixels[s + 1];
                    d[p + 2] = pixels[s];
                    d[p + 3] = 255;
                }
                else
                {
                    d[p] = pixels[s + 2];
                    d[p + 1] = pixels[s + 1];
                    d[p + 2] = pixels[s];
                    d[p + 3] = 255;
                }
            }
        }

        return bitmap;
    }

    private static SKBitmap Crop(SKBitmap page, PixelRect? crop)
    {
        if (crop is null)
        {
            return page.Copy() ?? throw new InvalidOperationException("Could not copy the page bitmap.");
        }

        PixelRect r = crop.Value;
        int x = Math.Clamp(r.X, 0, page.Width - 1);
        int y = Math.Clamp(r.Y, 0, page.Height - 1);
        int w = Math.Clamp(r.Width, 1, page.Width - x);
        int h = Math.Clamp(r.Height, 1, page.Height - y);
        SKBitmap part = new(w, h, SKColorType.Bgra8888, SKAlphaType.Opaque);
        using SKCanvas canvas = new(part);
        canvas.Clear(SKColors.White);
        canvas.DrawBitmap(page, new SKRect(x, y, x + w, y + h), new SKRect(0, 0, w, h));
        return part;
    }

    private static byte[] ToRgb(SKBitmap bitmap)
    {
        SKBitmap? copy = null;
        SKBitmap bgra = bitmap;
        if (bitmap.ColorType != SKColorType.Bgra8888)
        {
            copy = bitmap.Copy(SKColorType.Bgra8888)
                ?? throw new InvalidOperationException("Could not convert the barcode crop to BGRA.");
            bgra = copy;
        }

        try
        {
            IntPtr srcPtr = bgra.GetPixels();
            if (srcPtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Barcode crop has no pixel buffer.");
            }

            byte[] rgb = new byte[bgra.Width * bgra.Height * 3];
            unsafe
            {
                byte* src = (byte*)srcPtr.ToPointer();
                int stride = bgra.RowBytes;
                int i = 0;
                for (int y = 0; y < bgra.Height; y++)
                {
                    byte* row = src + (y * stride);
                    for (int x = 0; x < bgra.Width; x++)
                    {
                        int p = x * 4;
                        rgb[i++] = row[p + 2];
                        rgb[i++] = row[p + 1];
                        rgb[i++] = row[p];
                    }
                }
            }

            return rgb;
        }
        finally
        {
            copy?.Dispose();
        }
    }
}
