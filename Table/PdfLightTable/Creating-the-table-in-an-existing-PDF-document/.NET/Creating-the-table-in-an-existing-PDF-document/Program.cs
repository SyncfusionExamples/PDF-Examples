using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Tables;
using Syncfusion.Pdf;
using System.Reflection.Metadata;

//Load the PDF document. 
using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Data/Input.pdf")))
{
    //Get the first page from the document
    PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

    //Create PDF graphics for the page
    PdfGraphics graphics = page.Graphics;

    //Create a PdfLightTable.
    PdfLightTable pdfLightTable = new PdfLightTable();

    //Add values to the list.
    List<object> data = new List<object>();
    object row = new { Name = "abc", Age = "21", Sex = "Male" };
    data.Add(row);

    //Add list to IEnumerable.
    IEnumerable<object> table = data;

    //Assign data source.
    pdfLightTable.DataSource = table;

    //Draw PdfLightTable.
    pdfLightTable.Draw(graphics, new Syncfusion.Drawing.PointF(0, 0));

    //Save the PDF document
    loadedDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
