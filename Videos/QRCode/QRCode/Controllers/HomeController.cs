using Microsoft.AspNetCore.Mvc;
using QRCode.Models;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.Diagnostics;

namespace QRCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult AddQRToPDF()
        {
            //Load the existing PDF file
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("data/input.pdf");

            //Create a QR code
            PdfQRBarcode qrBarcode = new PdfQRBarcode();

            qrBarcode.Text = "support@adventure-works.com";

            qrBarcode.XDimension = 2.5f;

            //Get the first page of the PDF document
            PdfLoadedPage? loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

            //Draw the QR code on that page
            qrBarcode.Draw(loadedPage!, new PointF(50, 710));

            // Return the PDF as a downloadable file
            return ExportPDF(loadedDocument, "qrcode.pdf");
        }

        public IActionResult CustomizeQR()
        {
            //Load the existing PDF file
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("data/input.pdf");

            //Create a QR code
            PdfQRBarcode qrBarcode = new PdfQRBarcode();

            // Set QR code properties
            qrBarcode.Text = "https://www.syncfusion.com/document-sdk";

            //Set the QR size
            qrBarcode.Size = new SizeF(75, 75);

            qrBarcode.XDimension = 5;

            // Error correction configuration
            qrBarcode.ErrorCorrectionLevel = PdfErrorCorrectionLevel.High;

            // Encoding mode optimization
            qrBarcode.InputMode = InputMode.BinaryMode;

            // Version control (1-40 or Auto)
            qrBarcode.Version = QRCodeVersion.Version10;

            // Foreground color for QR pattern
            qrBarcode.ForeColor = Color.White;

            // Background color
            qrBarcode.BackColor = new PdfColor(46, 197, 190);

            //Set quiet zone (margin) around the QR code
            qrBarcode.QuietZone = new PdfBarcodeQuietZones() { All = 5 };

            //Get the first page of the PDF document
            PdfLoadedPage? loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

            //Draw the QR code on that page
            qrBarcode.Draw(loadedPage!, new PointF(50, 710));

            // Return the PDF as a downloadable file
            return ExportPDF(loadedDocument, "qrcode-customization.pdf");
        }

        public IActionResult QRWithLogo()
        {
            //Load the existing PDF file
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("data/input.pdf");

            //Create a QR code
            PdfQRBarcode qrBarcode = new PdfQRBarcode();

            // Set QR code properties
            qrBarcode.Text = "https://www.syncfusion.com/document-sdk";

            //Set the QR size
            qrBarcode.Size = new SizeF(75, 75);

            qrBarcode.XDimension = 5;

            // Error correction configuration
            qrBarcode.ErrorCorrectionLevel = PdfErrorCorrectionLevel.High;

            // Encoding mode optimization
            qrBarcode.InputMode = InputMode.BinaryMode;

            // Version control (1-40 or Auto)
            qrBarcode.Version = QRCodeVersion.Version10;

            // Foreground color for QR pattern
            qrBarcode.ForeColor = Color.White;

            // Background color
            qrBarcode.BackColor = new PdfColor(46, 197, 190);

            //Set quiet zone (margin) around the QR code
            qrBarcode.QuietZone = new PdfBarcodeQuietZones() { All = 5 };

            //Get the first page of the PDF document
            PdfLoadedPage? loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

            //Create logo for QR code
            QRCodeLogo logo = new QRCodeLogo(PdfBitmap.FromStream(new FileStream("data\\logo.png", FileMode.Open, FileAccess.Read)));

            //Set logo in qrcode
            qrBarcode.Logo = logo;

            //Draw the QR code on that page
            qrBarcode.Draw(loadedPage!, new PointF(50, 710));
          
            // Return the PDF as a downloadable file
            return ExportPDF(loadedDocument, "qrcode-with-logo.pdf");
        }

        public IActionResult QRToHeader()
        {
            // Create a new PDF document instance
            PdfDocument document = new PdfDocument();

            //Add page to the document
            PdfPage page = document.Pages.Add();

            //Get the page size
            SizeF pageSize = page.GetClientSize();

            //Create the header template and add to the document
            document.Template.Top = CreateHeaderTemplate(new SizeF(pageSize.Width, 100));

            //Read the text from the text file
            string text = System.IO.File.ReadAllText("data\\input.txt");

            // Create a standard Helvetica font with size 12
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

            // Create a text element using the file content and fon
            PdfTextElement element = new PdfTextElement(text, font);

            // Draw the text element on the PDF page
            element.Draw(page, new PointF(0, 0));

            // Create a memory stream to hold the output PDF
            MemoryStream outputStream = new MemoryStream();

            // Save the document to the memory stream
            document.Save(outputStream);

            // Reset the stream position to the beginning
            outputStream.Position = 0;

            // Close the document and release resources
            document.Close(true);

            // Return the PDF as a downloadable file
            return File(outputStream, "application/pdf", "qrcode-in-header.pdf");
        }

        //Create header template and return
        PdfPageTemplateElement CreateHeaderTemplate(SizeF headerSize)
        {
            //Create PdfPageTemplateElement
            PdfPageTemplateElement header = new PdfPageTemplateElement(new RectangleF(0, 0, headerSize.Width, headerSize.Height));

            // Create a font for the header text
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Regular);

            //Draw the text with center alignment
            header.Graphics.DrawString("PDF Succinctly", font, PdfBrushes.Black, new PointF(0, (headerSize.Height - font.Height) / 2));

            //Create a QR code and draw
            PdfQRBarcode qrBarcode = new PdfQRBarcode()
            {
                Text = "https://www.syncfusion.com/succinctly-free-ebooks/pdf",
                Size = new SizeF(75, 75),
            };

            //Draw the QR code on the header
            qrBarcode.Draw(header.Graphics, new PointF(headerSize.Width - (qrBarcode.Size.Width + 40), (headerSize.Height - qrBarcode.Size.Height) / 2));

            //Draw line to separate header
            header.Graphics.DrawLine(new PdfPen(PdfBrushes.LightGray, 0.5f), new PointF(0, headerSize.Height - 5), new PointF(headerSize.Width, headerSize.Height - 5));

            return header;
        }


        // Helper method to save the modified PDF and return it as a file result
        private FileStreamResult ExportPDF(PdfLoadedDocument document, string fileName)
        {
            // Create a memory stream to hold the output PDF
            MemoryStream outputStream = new MemoryStream();

            // Save the document to the memory stream
            document.Save(outputStream);

            // Reset the stream position to the beginning
            outputStream.Position = 0;

            // Close the document and release resources
            document.Close(true);

            // Return the PDF as a downloadable file
            return File(outputStream, "application/pdf", fileName);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
