using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Tables;
using System.Data;

//Create a new PDF document.
using (PdfDocument document = new PdfDocument())
{
    //Add a page.
    PdfPage page = document.Pages.Add();

    //Create a PdfLightTable.
    PdfLightTable pdfLightTable = new PdfLightTable();

    //Initialize DataTable to assign as DateSource to the light table.
    DataTable table = new DataTable();

    //Include columns to the DataTable.
    table.Columns.Add("Name");
    table.Columns.Add("Age");
    table.Columns.Add("Sex");

    //Include rows to the DataTable.
    table.Rows.Add(new string[] { "abc", "21", "Male" });

    //Assign data source.
    pdfLightTable.DataSource = table;

    //Set to view the table header. 
    pdfLightTable.Style.ShowHeader = true;

    //Draw PdfLightTable.
    pdfLightTable.Draw(page, new PointF(0, 0));

    //Save the PDF document
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
