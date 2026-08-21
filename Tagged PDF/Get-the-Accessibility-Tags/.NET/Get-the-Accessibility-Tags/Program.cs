using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

// Load the existing PDF document.
using (PdfLoadedDocument document = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    // Get the structure element root from the document.
    PdfStructureElement rootElement = document.StructureElement;
    // Get the child elements.
    PdfStructureElement[] childElements = rootElement.ChildElements;
    // Get the first child element.
    PdfStructureElement element = childElements[0];
    // Display the element properties in the console.
    Console.WriteLine($"Abbreviation   : {element.Abbrevation}");
    Console.WriteLine($"Actual Text    : {element.ActualText}");
    Console.WriteLine($"Alternate Text : {element.AlternateText}");
    Console.WriteLine($"Language       : {element.Language}");
    Console.WriteLine($"Order          : {element.Order}");
    Console.WriteLine($"Tag Type       : {element.TagType}");
    Console.WriteLine($"Title          : {element.Title}");
    Console.WriteLine($"Scope          : {element.Scope}");
    Console.WriteLine($"Bounds         : {element.Bounds}");
    // Display parent element information.
    PdfStructureElement parent = element.Parent;
    Console.WriteLine($"Parent Title   : {parent?.Title}");
}