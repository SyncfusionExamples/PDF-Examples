using Syncfusion.Drawing;
using Syncfusion.Metafile;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Open the WMF file as a stream.
using (FileStream metafileStream = new FileStream(Path.GetFullPath(@"Data/Input.emf"), FileMode.Open, FileAccess.Read))
{
    //Create a new instance of the MetafileRenderer class.
    MetafileRenderer renderer = new MetafileRenderer();
    //Convert the Metafile stream to a PdfTemplate.
    PdfTemplate template = renderer.ConvertToPdfTemplate(metafileStream);
    //Set the page size to match the template size.
    document.PageSettings.Size = new SizeF(template.Size);
    //Remove page margins.
    document.PageSettings.Margins.All = 0;
    //Add a page to the document.
    PdfPage page = document.Pages.Add();
    //Get the PDF page graphics.
    PdfGraphics graphics = page.Graphics;
    //Draw the template on the PDF page.
    graphics.DrawPdfTemplate(template, PointF.Empty);
}
//Save the PDF document.
document.Save(Path.GetFullPath(@"Output/Output.pdf"));
//Close the document.
document.Close(true);