// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
PdfDocument document = new PdfDocument();

//Add a page.
PdfPage page = document.Pages.Add();

//Create a PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Add a handler to rotate the table.
pdfGrid.BeginPageLayout += PdfGrid_BeginPageLayout;

//Add values to the list.
List<object> data = new List<object>();

Object row1 = new { ID = "57", Name = "AAA", Type = "ABC", Date = DateTime.Now };
Object row2 = new { ID = "130", Name = "BBB", Type = "BCD", Date = DateTime.Now };
Object row3 = new { ID = "92", Name = "CCC", Type = "CDE", Date = DateTime.Now };

data.Add(row1);
data.Add(row2);
data.Add(row3);

//Add list to the IEnumerable.
IEnumerable<object> dataTable = data;

//Assign data source.
pdfGrid.DataSource = dataTable;

//Set a repeat header for the table. 
pdfGrid.RepeatHeader = true;

//Draw a grid to the page of a PDF document.
pdfGrid.Draw(page, new RectangleF(100, 20, 0, page.GetClientSize().Width));

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);



void PdfGrid_BeginPageLayout(object sender, BeginPageLayoutEventArgs e)
{
    PdfPage page = e.Page;
    PdfGraphics graphics = e.Page.Graphics;

    //Translate the coordinate system to the required position.
    graphics.TranslateTransform(page.GetClientSize().Width, 0);

    //Rotate the coordinate system.
    graphics.RotateTransform(90);
}
