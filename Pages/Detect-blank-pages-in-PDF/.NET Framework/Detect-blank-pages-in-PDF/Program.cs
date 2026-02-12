using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.PdfToImageConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Detect_blank_pages_in_PDF
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (FileStream file = new FileStream(Path.GetFullPath("Data/Input.pdf"), FileMode.Open, FileAccess.Read))
            {
                // Load the existing PDF document
                PdfLoadedDocument ldoc = new PdfLoadedDocument(file);
                PdfToImageConverter converter = new PdfToImageConverter();
                converter.Load(file);
                List<int> emptyPages = new List<int>();
                for (int i = 0; i < ldoc.Pages.Count; i++)
                {
                    PdfLoadedPage lpage = ldoc.Pages[i] as PdfLoadedPage;
                    if (IsBlankPage(lpage, i, converter))
                    {
                        emptyPages.Add(i + 1);  // +1 because pages are normally 1‑based
                        Console.WriteLine($"Page {i + 1} is blank.");
                    }
                }
                ldoc.Close(true);
                Console.WriteLine();
                Console.WriteLine($"Total blank pages: {emptyPages.Count}");
            }

        }
        // Determines whether a page is blank.
        private static bool IsBlankPage(PdfLoadedPage lpage, int pageIndex, PdfToImageConverter converter)
        {
            bool isBlankPage = false;

            if (lpage.Annotations.Count > 0)
            {
                isBlankPage = false;
                return isBlankPage;
            }
            // For images.
            System.Drawing.Image[] images = lpage.ExtractImages();

            if (images.Length > 0)
            {
                foreach (System.Drawing.Image img in images)
                {
                    if (!IsEmpty(img as Bitmap))
                    {
                        isBlankPage = false;
                        break;
                    }
                    else
                        isBlankPage = true;
                }
            }
            else
            {
                //For shapes
                Stream imageSteam = converter.Convert(pageIndex, false, false);
                imageSteam.Position = 0;
                if (imageSteam != null && IsEmpty(new Bitmap(imageSteam)))
                {
                    isBlankPage = true;
                }
                else
                {
                    isBlankPage = false;
                }

            }
            return isBlankPage;
        }
        // Determines if a bitmap is "empty" by counting non-white pixels.
        private static bool IsEmpty(Bitmap image)
        {
            Rectangle bounds = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData bmpData = image.LockBits(bounds, ImageLockMode.ReadWrite, image.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * image.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);
            image.UnlockBits(bmpData);
            // Count non-white pixels
            int nonWhitePixelCount = rgbValues.Count(b => b != 255);
            // If less than 1% of pixels are non-white, consider it blank
            int threshold = (image.Width * image.Height) / 100; // 1%
            return nonWhitePixelCount < threshold;
        }
    }
}
