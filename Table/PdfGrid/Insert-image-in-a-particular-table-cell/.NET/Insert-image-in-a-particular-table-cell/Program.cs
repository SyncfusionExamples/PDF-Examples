using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Create the page.
    PdfPage pdfPage = document.Pages.Add();

    //Create a new PdfGrid.
    PdfGrid pdfGrid = new PdfGrid();

    //Add values to the list.
    List<object> data = new List<object>();
    Object row1 = new { SNO = "1", Image = "" };
    data.Add(row1);

    //Add list to the IEnumerable.
    IEnumerable<object> dataTable = data;

    //Assign data source.
    pdfGrid.DataSource = dataTable;

    //Set the row height. 
    pdfGrid.Rows[0].Height = 100;

    //Call the event handler to draw the image in a particular cell. 
    pdfGrid.BeginCellLayout += PdfGrid_BeginCellLayout;

    //Draw a grid to the page of a PDF document.
    pdfGrid.Draw(pdfPage, new PointF(10, 10));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

static void PdfGrid_BeginCellLayout(object sender, PdfGridBeginCellLayoutEventArgs args)
{
    if (args.CellIndex == 1 && !args.IsHeaderRow)
    {
        //Load the image from the disk.
        FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Support.jpg"), FileMode.Open, FileAccess.Read);
        PdfBitmap image = new PdfBitmap(imageStream);

        //Insert the image in a table cell. 
        args.Graphics.DrawImage(image, args.Bounds.X, args.Bounds.Y + 10, args.Bounds.Width, args.Bounds.Height - 10);
    }
}
