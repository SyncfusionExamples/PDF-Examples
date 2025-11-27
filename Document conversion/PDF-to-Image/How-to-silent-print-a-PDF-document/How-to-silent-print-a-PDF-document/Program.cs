using Syncfusion.PdfToImageConverter;
using System.Drawing;
using System.Drawing.Printing;

// Initialize the PdfToImageConverter with the path to the PDF file
using (PdfToImageConverter imageConverter = new PdfToImageConverter())
{
    // Load the PDF document
    imageConverter.Load(new FileStream("Data/Input.pdf", FileMode.Open, FileAccess.Read));

    //Convert all the PDF pages to images
    Stream[] images = imageConverter.Convert(0, imageConverter.PageCount - 1, false, false);

    //Create a print document object to print the images
    using (PrintDocument printDocument = new PrintDocument())
    {
        int currentPageIndex = 0;
        //Handle the PrintPage event to print each image
        printDocument.PrintPage += (sender, e) =>
        {
            Stream imageStream = images[currentPageIndex];
            imageStream.Position = 0; // Reset stream position
            Image currentImage = Image.FromStream(imageStream);
            //Draw the current image on the print page
            e.Graphics.DrawImage(currentImage, e.PageBounds);
            //Move to the next page
            currentPageIndex++;
            //Check if there are more pages to print
            e.HasMorePages = currentPageIndex < images.Length;
        };
        //Print the document
        printDocument.Print();
    }
}