// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

//Creates a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Set the document information title. 
pdfDocument.DocumentInformation.Title = "Table";

//Adds new page.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Initialize the new structure element with tag type table.
PdfStructureElement element = new PdfStructureElement(PdfTagType.Table);

//Create a new PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Adding tag to PDF grid.
pdfGrid.PdfTag = element;

//Add three columns.
pdfGrid.Columns.Add(3);

//Add header.
pdfGrid.Headers.Add(1);

//Set table header.
PdfGridRow pdfGridHeader = pdfGrid.Headers[0];

//Set font and brush. 
pdfGridHeader.Style.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
pdfGridHeader.Style.TextBrush = PdfBrushes.Brown;

//Adding tag for each row with tag type TR.
pdfGridHeader.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

//Set the cell value.  
pdfGridHeader.Cells[0].Value = "Employee ID";

//Adding tag for header cell with tag type TH
pdfGridHeader.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);

//Set the cell value. 
pdfGridHeader.Cells[1].Value = "Employee Name";

//Adding tag for header cell with tag type TH.
pdfGridHeader.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);

//Set the cell value. 
pdfGridHeader.Cells[2].Value = "Salary";

//Adding tag for header cell with tag type TH.
pdfGridHeader.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableHeader);

//Add rows.
PdfGridRow pdfGridRow = pdfGrid.Rows.Add();

//Add tag to table row.
pdfGridRow.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

//Set the cell values. 
pdfGridRow.Cells[0].Value = "E01";
pdfGridRow.Cells[1].Value = "Clay";
pdfGridRow.Cells[2].Value = "$10,000";

//Adding tag for each cell with tag type TD.
pdfGridRow.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
pdfGridRow.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
pdfGridRow.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

//Draw the PdfGrid
pdfGrid.Draw(pdfPage, PointF.Empty);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    pdfDocument.Save(outputFileStream);
}

//Close the document.
pdfDocument.Close(true);
