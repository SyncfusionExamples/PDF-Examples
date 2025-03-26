using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

// Create a new PDF document
PdfDocument document = new PdfDocument();

// Create a role map to define custom structure roles 
PdfRoleMap roleMap = new PdfRoleMap();
roleMap.Add("WorkBook", "Document"); // Mapping "WorkBook" to "Document" 
roleMap.Add("WorkSheet", "Sect"); // Mapping "WorkSheet" to "Sect" 

// Define a custom structure type 
string customStructureType = "WorkBook";
string standardStructureType = "";

// Try to get the standard structure type for the custom role 
bool found = roleMap.TryGetStandardType(customStructureType, out standardStructureType);
document.StructureRoleMap = roleMap; // Assign role map to the document 

// Set document metadata 
document.DocumentInformation.Title = "Custom Role Map";

// Add a new page to the PDF 
PdfPage page = document.Pages.Add();

// Create a custom structure element with a specified role 
PdfStructureElement structureElement = new PdfStructureElement("WorkBook");
structureElement.ActualText = "Simple paragraph element"; // Set alternative text for accessibility 

// Define the content text 
string text = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European, and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";

// Create a text element and associate it with the structure element 
PdfTextElement element = new PdfTextElement(text);
element.PdfTag = structureElement;

//Load the font file as stream  
FileStream fontStream = new FileStream(Path.GetFullPath(@"Data/Font.ttf"), FileMode.Open, FileAccess.Read);

// Set font and color for the text 
element.Font = new PdfTrueTypeFont(fontStream, 10);
element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));

// Draw text on the page 
PdfLayoutResult result = element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width, 200));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);