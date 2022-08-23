// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new instance of PdfDocument class.
PdfDocument document = new PdfDocument();

//Create a new portfolio.
document.PortfolioInformation = new PdfPortfolioInformation();

//Set the view mode of the portfolio.
document.PortfolioInformation.ViewMode = PdfPortfolioViewMode.Tile;

//Get stream from the attachment PDF file. 
FileStream pdfStream = new FileStream(Path.GetFullPath("../../../CorporateBrochure.pdf"), FileMode.Open, FileAccess.Read);

//Create the attachment.
PdfAttachment pdfFile = new PdfAttachment("CorporateBrochure.pdf", pdfStream);

//Set the file name. 
pdfFile.FileName = "CorporateBrochure.pdf";

//Set the startup document to view.
document.PortfolioInformation.StartupDocument = pdfFile;

//Add the attachment to the document.
document.Attachments.Add(pdfFile);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);