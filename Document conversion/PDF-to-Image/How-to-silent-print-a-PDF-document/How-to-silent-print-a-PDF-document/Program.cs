using Syncfusion.PdfToImageConverter;
using System.Drawing;
using System.Drawing.Printing;

class Program
{
    static Bitmap[] bitmaps;
    static int currentPageIndex = 0;
    static void Main()
    {
        // Initialize PDF to Image converter.
        PdfToImageConverter imageConverter = new PdfToImageConverter();
        // Load the PDF document as a stream
        using (FileStream inputStream = new FileStream("Data/Input.pdf", FileMode.Open, FileAccess.ReadWrite))
        {
            imageConverter.Load(inputStream);
            // Convert PDF to Image.
            Stream[] outputStream = imageConverter.Convert(0, imageConverter.PageCount - 1, false, false);
            // Convert streams to bitmaps.
            bitmaps = BitmapConverter.ConvertStreamsToBitmaps(outputStream);
        }
        // Initialize PrintDocument
        PrintDocument printDocument = new PrintDocument();
        // Attach the PrintPage event handler
        printDocument.PrintPage += PrintDocument_PrintPage;
        // Print the document
        printDocument.Print();
    }
    private static void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        Bitmap bitmap = bitmaps[currentPageIndex];
        Graphics graphics = e.Graphics;
        // Center the image on the page without scaling
        float offsetX = (e.PageBounds.Width - bitmap.Width) / 2;
        float offsetY = (e.PageBounds.Height - bitmap.Height) / 2;
        graphics.DrawImage(bitmap, offsetX, offsetY);
        currentPageIndex++;
        e.HasMorePages = currentPageIndex < bitmaps.Length;
        if (!e.HasMorePages)
        {
            currentPageIndex = 0;
        }
    }
    public static class BitmapConverter
    {
        public static Bitmap[] ConvertStreamsToBitmaps(Stream[] streams)
        {
            Bitmap[] bitmaps = new Bitmap[streams.Length];
            for (int i = 0; i < streams.Length; i++)
            {
                bitmaps[i] = new Bitmap(streams[i]);
            }
            return bitmaps;
        }
    }
}