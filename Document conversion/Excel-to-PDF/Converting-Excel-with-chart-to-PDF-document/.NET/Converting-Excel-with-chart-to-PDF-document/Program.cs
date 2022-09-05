// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;

using (ExcelEngine excelEngine = new ExcelEngine())
{
    IApplication application = excelEngine.Excel;

    //Initialize XlsIO renderer.
    XlsIORenderer renderer = new XlsIORenderer();

    //Get stream from an existing Excel file. 
    FileStream excelStream = new FileStream(Path.GetFullPath("../../../EmbeddedChart.xlsx"), FileMode.Open, FileAccess.Read);
    IWorkbook workbook = application.Workbooks.Open(excelStream);

    //Convert Excel document with charts into PDF document 
    PdfDocument pdfDocument = renderer.ConvertToPDF(workbook);

    //Save the PDF document. 
    Stream stream = new FileStream(Path.GetFullPath("../../../ExcelToPDF.pdf"), FileMode.Create, FileAccess.ReadWrite);
    pdfDocument.Save(stream);

    excelStream.Dispose();
    stream.Dispose();

    //Close the PDF document. 
    pdfDocument.Close(true);
}
