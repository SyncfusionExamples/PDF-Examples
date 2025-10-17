using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Create a PdfLightTable
    PdfLightTable pdfLightTable = new PdfLightTable();

    //Set the DataSourceType as Direct.
    pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

    //Create columns.
    pdfLightTable.Columns.Add(new PdfColumn("Roll Number"));
    pdfLightTable.Columns.Add(new PdfColumn("Name"));
    pdfLightTable.Columns.Add(new PdfColumn("Class"));

    //Add rows.
    pdfLightTable.Rows.Add(new object[] { "111", "Maxim", "III" });
    pdfLightTable.Rows.Add(new object[] { "112", "Minim", "III" });

    //Subscribing to events.
    pdfLightTable.BeginCellLayout += PdfLightTable_BeginCellLayout;
    pdfLightTable.EndCellLayout += PdfLightTable_EndCellLayout;

    //Show the table header.
    pdfLightTable.Style.ShowHeader = true;

    //Draw the PdfLightTable.
    pdfLightTable.Draw(page, Syncfusion.Drawing.PointF.Empty);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}

void PdfLightTable_EndCellLayout(object sender, EndCellLayoutEventArgs args)
{
    if (args.RowIndex == 0 && args.CellIndex == 0)
    {
        //Load the image as stream
        FileStream imageStream = new FileStream(Path.GetFullPath(@"Data/Image.jpg"), FileMode.Open, FileAccess.Read);
        args.Graphics.DrawImage(new PdfBitmap(imageStream), args.Bounds);
    }
}

void PdfLightTable_BeginCellLayout(object sender, BeginCellLayoutEventArgs args)
{
    if (args.RowIndex == 0 && args.CellIndex == 1)
    {
        args.Graphics.DrawEllipse(PdfBrushes.Red, args.Bounds);
    }
}