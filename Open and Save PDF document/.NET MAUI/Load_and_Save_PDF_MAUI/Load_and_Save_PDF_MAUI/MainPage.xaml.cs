using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using CreatePdfSample.Services;
using System.Reflection;

namespace Load_and_Save_PDF_MAUI;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void ButtonClick(object sender, EventArgs e)
	{
        //Open an existing PDF document.
        Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;
        string basePath = "Load_and_Save_PDF_MAUI.Resources.Data.";
        Stream inputStream = assembly.GetManifestResourceStream(basePath + "Input.pdf");
        PdfLoadedDocument document = new PdfLoadedDocument(inputStream);
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

        //Saves the PDF to the memory stream.
        using MemoryStream ms = new();
        document.Save(ms);
        //Close the PDF document
        document.Close(true);
        ms.Position = 0;
        //Saves the memory stream as file.
        SaveService saveService = new();
        saveService.SaveAndView("Result.pdf", "application/pdf", ms);
    }
}

