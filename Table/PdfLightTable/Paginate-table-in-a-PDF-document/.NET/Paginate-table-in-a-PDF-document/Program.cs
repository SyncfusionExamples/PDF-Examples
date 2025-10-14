using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Create a PdfLightTable.
    PdfLightTable pdfLightTable = new PdfLightTable();

    //Add values to list.
    List<object> data = new List<object>();

    //you can add multiple rows
    Object row = new { Name = "abc", Age = "21", Sex = "Male" };

    for (int i = 0; i < 500; i++)
        data.Add(row);

    //Add list to IEnumerable.
    IEnumerable<object> table = data;

    //Assign data source.
    pdfLightTable.DataSource = table;

    //Set properties to paginate the table.
    PdfLightTableLayoutFormat layoutFormat = new PdfLightTableLayoutFormat();
    layoutFormat.Break = PdfLayoutBreakType.FitPage;
    layoutFormat.Layout = PdfLayoutType.Paginate;

    //Set to view the table header. 
    pdfLightTable.Style.ShowHeader = true;

    //Draw PdfLightTable.
    pdfLightTable.Draw(page, new Syncfusion.Drawing.PointF(0, 0), layoutFormat);

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}


