using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.PdfToImageConverter;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace How_to_detect_blank_Pages_in_a_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("Data", "*.pdf");

            foreach (string file in files)
            {
                //Load the existing PDF document
                PdfLoadedDocument ldoc = new PdfLoadedDocument(file);

                PdfToImageConverter converter = new PdfToImageConverter();
                converter.Load(new FileStream(file, FileMode.Open));

                int blankPageCount = 0;

                for (int i = 0; i < ldoc.Pages.Count; i++)
                {
                    PdfLoadedPage lpage = ldoc.Pages[i] as PdfLoadedPage;
                    if (IsBlankPage(lpage, i, converter))
                        blankPageCount++;
                }

                ldoc.Close(true);

                Console.WriteLine(file + " has " + blankPageCount + " blank pages");
            }
        }
        private static bool IsBlankPage(PdfLoadedPage lpage, int pageIndex, PdfToImageConverter converter)
        {
            bool isBlankPage = false;

            if (lpage.Annotations.Count > 0)
            {
                isBlankPage = false;
                return isBlankPage;
            }
            // For images.
            Image[] images = lpage.ExtractImages();

            if (images.Length > 0)
            {
                foreach (Image img in images)
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
