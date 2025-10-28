using Syncfusion.Pdf;

// Create an instance of the ImageToPdfConverter class 
ImageToPdfConverter imageToPdfConverter = new ImageToPdfConverter();
// Set the page size for the document
imageToPdfConverter.PageSize = PdfPageSize.A4;
// Set the position of the image in the document
imageToPdfConverter.ImagePosition = PdfImagePosition.TopLeftCornerOfPage;
// Create a file stream to read the image file 
using (FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Autumn Leaves.jpg"), FileMode.Open, FileAccess.Read))
// Convert the image to a PDF document using the ImageToPdfConverter 
using (PdfDocument pdfDocument = imageToPdfConverter.Convert(imageStream))
{
    //Save the PDF document
    pdfDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}