using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;

using (ExcelEngine excelEngine = new ExcelEngine())
{
    IApplication application = excelEngine.Excel;
    FileStream excelStream = new FileStream(Path.GetFullPath(@"Data/ExcelToPDF.xlsx"), FileMode.Open, FileAccess.Read);
    IWorkbook workbook = application.Workbooks.Open(excelStream);
    IWorksheet worksheet = workbook.Worksheets[0];

    //Initialize XlsIO renderer.
    XlsIORenderer renderer = new XlsIORenderer();

    //Convert Excel document into PDF document 
    PdfDocument pdfDocument = renderer.ConvertToPDF(worksheet);
    pdfDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));

    excelStream.Dispose();
}
