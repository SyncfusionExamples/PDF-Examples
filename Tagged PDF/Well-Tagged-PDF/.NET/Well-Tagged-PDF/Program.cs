using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document 
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A4);

//Set Pdf File version 2.0 
document.FileStructure.Version = PdfVersion.Version2_0;

//Set true to auto tag all elements in document 
document.AutoTag = true;
document.DocumentInformation.Title = "PdfTextElement";

// Add a new page 
PdfPage page = document.Pages.Add();

//Load the font file as stream 
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/Font.ttf"), FileMode.Open, FileAccess.Read);

// Initialize the structure element with tag type paragraph 
PdfStructureElement paragraphStructure = new PdfStructureElement(PdfTagType.Paragraph);

// Represents the text that is the exact replacement for PdfTextElement 
paragraphStructure.ActualText = "Simple paragraph element";
string paragraphText = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European, and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";

// Initialize the PDF text element 
PdfTextElement textElement = new PdfTextElement(paragraphText);

// Adding tag to the text element 
textElement.PdfTag = paragraphStructure;

// Create font for the text element 
textElement.Font = new PdfTrueTypeFont(fontStream, 10);
textElement.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));

// Draw text element with tag 
textElement.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width, 200));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);