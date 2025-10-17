using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
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

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
