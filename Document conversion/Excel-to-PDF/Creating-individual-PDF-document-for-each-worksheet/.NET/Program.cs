﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;

using (ExcelEngine excelEngine = new ExcelEngine())
{
    IApplication application = excelEngine.Excel;

    //Load the Excel document as stream. 
    FileStream excelStream = new FileStream(Path.GetFullPath(@"Data/ExcelToPDF.xlsx"), FileMode.Open, FileAccess.Read);
    
    //Open workbook. 
    IWorkbook workbook = application.Workbooks.Open(excelStream);

    //Initialize XlsIO renderer.
    XlsIORenderer renderer = new XlsIORenderer();

    //Create PDF document. 
    PdfDocument pdfDocument = new PdfDocument();

    foreach (IWorksheet sheet in workbook.Worksheets)
    {
        //Convert Excel to PDF document. 
        pdfDocument = renderer.ConvertToPDF(sheet);

        //Save the PDF file.
        pdfDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
    }

    excelStream.Dispose();
}
