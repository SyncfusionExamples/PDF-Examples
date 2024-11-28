// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Create FileStream object to read the input PDF file
using (FileStream inputFileStream = new FileStream(Path.GetFullPath(@"Data/input.pdf"), FileMode.Open, FileAccess.Read))
{
    //Load the PDF document from the input stream
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream))
    {
        //Get the first page of the PDF document
        PdfPageBase loadedPage = loadedDocument.Pages[0];
        //Create a new popup annotation
        PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(new RectangleF(100, 100, 20, 20), "Comment");
        //Set the icon for the popup annotation
        popupAnnotation.Icon = PdfPopupIcon.Comment;
        //Set the color for the popup annotation
        popupAnnotation.Color = new PdfColor(Color.Yellow);
        //Add the annotation to the page
        loadedPage.Annotations.Add(popupAnnotation);
        //Create file stream.
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
        {
            //Save the PDF document to file stream.
            loadedDocument.Save(outputFileStream);
        }
    }
}
