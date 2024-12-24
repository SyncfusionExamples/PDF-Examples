// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using System.Data;

//Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    //Add a page
    PdfPage page = document.Pages.Add();

    //Create a PdfGrid
    PdfGrid pdfGrid = new PdfGrid();

    //Add values to the list
    List<object> data = new List<object>();
    data.Add(new { ID = "E01", Name = "Clay" });
    data.Add(new { ID = "E02", Name = "Thomas" });
    data.Add(new { ID = "E03", Name = "John" });

    //Assign the data source
    pdfGrid.DataSource = data;

    //Draw the grid to the page of PDF document
    pdfGrid.Draw(page, new PointF(10, 10));

    //Create file stream.
    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
    {
        //Save the PDF document to file stream.
        document.Save(outputFileStream);
    }
}