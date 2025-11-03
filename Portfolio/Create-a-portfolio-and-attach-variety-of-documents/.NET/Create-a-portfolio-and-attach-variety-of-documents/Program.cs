using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create a new portfolio.
    document.PortfolioInformation = new PdfPortfolioInformation();
    //Set the view mode of the portfolio.
    document.PortfolioInformation.ViewMode = PdfPortfolioViewMode.Tile;
    //Get stream from the attachment PDF file. 
    FileStream pdfStream = new FileStream(Path.GetFullPath(@"Data/CorporateBrochure.pdf"), FileMode.Open, FileAccess.Read);
    // Set the name of the attachment file
    pdfFile.FileName = "CorporateBrochure.pdf";
    // Provide a description for the attachment
    pdfFile.Description = "This is a PDF document";
    // Set the creation date of the attachment
    pdfFile.CreationDate = DateTime.Now;
    // Specify the MIME type of the attachment (important for identifying file type)
    pdfFile.MimeType = "application/pdf";
    // Optionally, set the modification date if needed
    pdfFile.ModificationDate = DateTime.Now;
    // Optionally, set the relationship (e.g., "Data", "Source", etc.)
    pdfFile.Relationship = PdfAttachmentRelationship.Unspecified;
    // Set this attachment as the startup document in the PDF portfolio
    document.PortfolioInformation.StartupDocument = pdfFile;
    //Add the attachment to the document.
    document.Attachments.Add(pdfFile);
    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}