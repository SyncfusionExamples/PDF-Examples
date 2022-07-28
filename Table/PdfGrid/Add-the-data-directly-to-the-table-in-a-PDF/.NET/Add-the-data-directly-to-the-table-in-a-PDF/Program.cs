// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Add page to the PDF document. 
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create a new PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Add three columns.
pdfGrid.Columns.Add(3);

//Add header.
pdfGrid.Headers.Add(1);
PdfGridRow pdfGridHeader = pdfGrid.Headers[0];
pdfGridHeader.Cells[0].Value = "Employee ID";
pdfGridHeader.Cells[1].Value = "Employee Name";
pdfGridHeader.Cells[2].Value = "Salary";

//Add rows.
PdfGridRow pdfGridRow = pdfGrid.Rows.Add();
pdfGridRow.Cells[0].Value = "E01";
pdfGridRow.Cells[1].Value = "Clay";
pdfGridRow.Cells[2].Value = "$10,000";

//Draw the PdfGrid.
pdfGrid.Draw(pdfPage, PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);