// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;

using (ExcelEngine excelEngine = new ExcelEngine())
{
    IApplication application = excelEngine.Excel;
    FileStream excelStream = new FileStream(Path.GetFullPath(@"Data/ExcelToPDF.xlsx"), FileMode.Open, FileAccess.Read);
    IWorkbook workbook = application.Workbooks.Open(excelStream);

    //Initialize XlsIO renderer.
    XlsIORenderer renderer = new XlsIORenderer();

    //Convert Excel document into PDF document 
    PdfDocument pdfDocument = renderer.ConvertToPDF(workbook);

    Stream stream = new FileStream(Path.GetFullPath(@"Output/Output.pdf"), FileMode.Create, FileAccess.ReadWrite);
    pdfDocument.Save(stream);

    excelStream.Dispose();
    stream.Dispose();

    //Close the document. 
    pdfDocument.Close(true);
}
