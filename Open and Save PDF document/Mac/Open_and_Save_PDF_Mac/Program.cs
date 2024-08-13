
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;

//Open an existing PDF document.

FileStream stream = new FileStream(@"Data/Input.pdf", FileMode.Open, FileAccess.Read);

PdfLoadedDocument document = new PdfLoadedDocument(stream);

//Get the first page from a document.

PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;

//Create PDF graphics for the page.

PdfGraphics graphics = page.Graphics;



//Create a PdfGrid.

PdfGrid pdfGrid = new PdfGrid();

//Add values to the list.

List<object> data = new List<object>();

Object row1 = new { Product_ID = "1001", Product_Name = "Bicycle", Price = "10,000" };

Object row2 = new { Product_ID = "1002", Product_Name = "Head Light", Price = "3,000" };

Object row3 = new { Product_ID = "1003", Product_Name = "Break wire", Price = "1,500" };

data.Add(row1);

data.Add(row2);

data.Add(row3);

//Add list to IEnumerable.

IEnumerable<object> dataTable = data;



//Assign data source.

pdfGrid.DataSource = dataTable;

//Apply built-in table style.

pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent3);

//Draw the grid to the page of PDF document.

pdfGrid.Draw(graphics, new RectangleF(40, 400, page.Size.Width - 80, 0));

//Create a FileStream to save the PDF document.

using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite))

{

    //Save the PDF file.

    document.Save(outputStream);

}