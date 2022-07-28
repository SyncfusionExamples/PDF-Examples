// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Add page to PDF document. 
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create a new PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Add values to list.
List<object> data = new List<object>();
Object row1 = new { ID = "E01", Name = "John" };
Object row2 = new { ID = "E02", Name = "Thomas" };
Object row3 = new { ID = "E03", Name = "Peter" };
data.Add(row1);
data.Add(row2);
data.Add(row3);

//Add list to IEnumerable.
IEnumerable<object> dataTable = data;

//Assign data source.
pdfGrid.DataSource = dataTable;

//Create an instance of PdfGridRowStyle.
PdfGridRowStyle pdfGridRowStyle = new PdfGridRowStyle();
pdfGridRowStyle.BackgroundBrush = PdfBrushes.LightYellow;
pdfGridRowStyle.Font = new PdfStandardFont(PdfFontFamily.Courier, 10);
pdfGridRowStyle.TextBrush = PdfBrushes.Blue;
pdfGridRowStyle.TextPen = PdfPens.Pink;

//Set the height.
pdfGrid.Rows[2].Height = 50;

//Set style for the PdfGridRow.
pdfGrid.Rows[0].Style = pdfGridRowStyle;

//Draw the PdfGrid.
PdfGridLayoutResult result = pdfGrid.Draw(pdfPage, Syncfusion.Drawing.PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);
