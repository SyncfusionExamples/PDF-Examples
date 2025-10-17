using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get first page from document.
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create PDF graphics for the page.
    PdfGraphics graphics = page.Graphics;

    //Create a PdfGrid.
    PdfGrid pdfGrid = new PdfGrid();

    //Add values to list
    List<object> data = new List<object>();
    Object row1 = new { ID = "1", Name = "Clay" };
    Object row2 = new { ID = "2", Name = "Thomas" };
    data.Add(row1);
    data.Add(row2);

    //Add list to IEnumerable.
    IEnumerable<object> dataTable = data;

    //Assign data source.
    pdfGrid.DataSource = dataTable;

    //Draw grid to the page of PDF document.
    pdfGrid.Draw(graphics, new Syncfusion.Drawing.PointF(10, 30));

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}