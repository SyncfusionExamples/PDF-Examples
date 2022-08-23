// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Creating a new PDF document. 
PdfDocument document = new PdfDocument();

//Adding a new page to the PDF document.
PdfPage page = document.Pages.Add();

//Create a layer.
PdfLayer layer = document.Layers.Add("Layer");

//Set a lock state.  
layer.Locked = true;

//Create graphics for a layer.
PdfGraphics graphics = layer.CreateGraphics(page);

//Draw ellipse.
graphics.DrawEllipse(PdfPens.Red, new RectangleF(50, 50, 40, 40));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
