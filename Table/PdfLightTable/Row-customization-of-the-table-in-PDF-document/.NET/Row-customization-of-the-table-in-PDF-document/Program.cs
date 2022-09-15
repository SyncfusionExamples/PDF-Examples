// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Tables;
using Syncfusion.Pdf;
using System.Reflection.Metadata;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page.
PdfPage page = document.Pages.Add();

//Create a PdfLightTable.
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
pdfLightTable.Rows.Add(new object[] { "113", "john", "III" });
pdfLightTable.Rows.Add(new object[] { "114", "peter", "III" });

//Subscribe to events.
pdfLightTable.BeginRowLayout += pdfLightTable_BeginRowLayout;
pdfLightTable.EndRowLayout += pdfLightTable_EndRowLayout;

//Draw the PdfLightTable.
pdfLightTable.Draw(page, Syncfusion.Drawing.PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);


void pdfLightTable_EndRowLayout(object sender, EndRowLayoutEventArgs args)
{

    //Customize the rows when the row layout ends.
    if (args.RowIndex == 3)
        args.Cancel = true;

}

void pdfLightTable_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
{
    //Apply the column span.
    if (args.RowIndex == 1)
    {
        PdfLightTable table = (PdfLightTable)sender;
        int count = table.Columns.Count;
        int[] spanMap = new int[count];

        //Set just spanned cells. Negative values are not allowed.
        spanMap[0] = 2;
        spanMap[1] = 3;
        args.ColumnSpanMap = spanMap;
    }
}
