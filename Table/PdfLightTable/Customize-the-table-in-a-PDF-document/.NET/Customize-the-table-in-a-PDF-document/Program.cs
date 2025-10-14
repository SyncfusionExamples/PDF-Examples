using Syncfusion.Pdf.Tables;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Create a PdfLightTable.
    PdfLightTable pdfLightTable = new PdfLightTable();

    //Add values to the list.
    List<object> data = new List<object>();
    object row = new { Name = "abc", Age = "21", Sex = "Male" };
    data.Add(row);

    //Add list to IEnumerable.
    IEnumerable<object> table = data;

    //Assign data source.
    pdfLightTable.DataSource = table;

    //Declare and define light table style.
    PdfLightTableStyle lightTableStyle = new PdfLightTableStyle();

    //Set cell padding, which specifies the space between the border and content of the cell.
    lightTableStyle.CellPadding = 2;

    //Set cell spacing, which specifies the space between the adjacent cells.
    lightTableStyle.CellSpacing = 2;

    //Sets to show header in the table.
    lightTableStyle.ShowHeader = true;

    //Sets to repeat the header on each page.
    lightTableStyle.RepeatHeader = true;

    //Apply style.
    pdfLightTable.Style = lightTableStyle;

    //Draw PdfLightTable.
    pdfLightTable.Draw(page, new PointF(0, 0));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
