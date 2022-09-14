using CreatePdfSample.Services;
using Microsoft.Maui.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace CreatePdfSample;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void CreatePDF_Click(object sender, EventArgs e)
	{
        //Create a new PDF document.
        PdfDocument document = new PdfDocument();

        //Add a page to the document.
        PdfPage page = document.Pages.Add();

        //Create PDF graphics for the page.
        PdfGraphics graphics = page.Graphics;

        //Set font. 
        PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

        //Draw string. 
        graphics.DrawString("Hello World!!!", font, PdfBrushes.Olive, new Syncfusion.Drawing.PointF(10,10));

        //Saves the PDF to the memory stream.
        using MemoryStream ms = new();
        document.Save(ms);

        //Close the PDF document
        document.Close(true);
        ms.Position = 0;

        //Saves the memory stream as file.
        SaveService saveService = new();
        saveService.SaveAndView("Invoice.pdf", "application/pdf", ms);
    }
}

