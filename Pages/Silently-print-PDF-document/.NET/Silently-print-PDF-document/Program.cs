using Syncfusion.PdfToImageConverter;
using System.Drawing;
using System.Drawing.Printing;

namespace ConsoleApp
{

    internal class Program
    {
        // Global variables to track iteration and store converted images
        static int itr = 0;
        static Bitmap[] bitmaps;

        static void Main(string[] args)
        {
            // Initialize PDF to Image converter.
            PdfToImageConverter imageConverter = new PdfToImageConverter();

            // Load the PDF document from a file stream.
            using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/Input.pdf"), FileMode.Open, FileAccess.Read))
            {
                imageConverter.Load(inputStream);
            }

            // Initialize an array to store bitmaps for all pages except the last.
            bitmaps = new Bitmap[imageConverter.PageCount - 1];

            // Convert PDF pages to image streams.
            Stream[] outputStream = imageConverter.Convert(0, imageConverter.PageCount - 1, false, false);

            // Convert the output streams into Bitmap objects.
            bitmaps = BitmapConverter.ConvertStreamsToBitmaps(outputStream);

            // Initialize PrintDocument for printing the images.
            PrintDocument printDocument = new PrintDocument();

            // Subscribe to the PrintPage event to handle printing logic.
            printDocument.PrintPage += PrintDocument_PrintPage;

            // Start the print process.
            printDocument.Print();
        }

        /// <summary>
        /// Handles the PrintPage event to print the current image.
        /// </summary>
        private static void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Draw the current image onto the print page.
            e.Graphics.DrawImage(bitmaps[itr], 0, 0, e.PageBounds.Width, e.PageBounds.Height);

            // Check if there are more pages to print.
            e.HasMorePages = itr < bitmaps.Length - 1;

            // Move to the next image.
            itr++;
        }
    }

    /// <summary>
    /// Utility class to convert image streams to Bitmap objects.
    /// </summary>
    public class BitmapConverter
    {
        /// <summary>
        /// Converts an array of streams into an array of Bitmap objects.
        /// </summary>
        /// <param name="streams">Array of image streams.</param>
        /// <returns>Array of Bitmap objects.</returns>
        public static Bitmap[] ConvertStreamsToBitmaps(Stream[] streams)
        {
            Bitmap[] bitmaps = new Bitmap[streams.Length];

            // Convert each stream into a Bitmap object.
            for (int i = 0; i < streams.Length; i++)
            {
                bitmaps[i] = new Bitmap(streams[i]);
            }
            return bitmaps;
        }
    }

}
