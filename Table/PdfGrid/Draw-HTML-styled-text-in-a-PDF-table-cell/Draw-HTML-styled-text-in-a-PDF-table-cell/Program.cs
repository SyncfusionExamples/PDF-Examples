// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();

//Create the page.
PdfPage pdfPage = pdfDocument.Pages.Add();

//Create a new PdfGrid.
PdfGrid pdfGrid = new PdfGrid();

//Add columns.
pdfGrid.Columns.Add(2);

//Add row and cell values. 
PdfGridRow row1 = pdfGrid.Rows.Add();
row1.Cells[0].Value = "Product Name";
row1.Cells[1].Value = "Description";

//Add row and cell values.
PdfGridRow row2 = pdfGrid.Rows.Add();
row2.Cells[0].Value = "Essential PDF";

//Render the HTML text.
string htmlText = "<font color='#0000F8'><b>Essential PDF</b></font> is a <u><i>.NET library</i></u> " + "with the capability to produce <i>Adobe PDF files </i>.";
PdfHTMLTextElement richTextElement = new PdfHTMLTextElement(htmlText, new PdfStandardFont(PdfFontFamily.TimesRoman, 12), PdfBrushes.Black);

//Set the HTML styled text value to the table cell.
row2.Cells[1].Value = richTextElement;

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