using Syncfusion.Drawing;
using Certificate_to_PDF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace Certificate_to_PDF.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            ViewData["ExamModes"] = GetExamModes();
            return View(new CertificateModel
            {
                ParticipantName = "Mubashir Hasan Soherwardi",
                CompetitionTitle = "Khuda Ko Kyu Mane? Aur Mazhab Ko Kyu Apnaye?",
                DateText = "26th October 2025",
                ExamMode = "Online"
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCertificate(CertificateModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ExamModes"] = GetExamModes();
                return View("Index", model);
            }

            //Create a new PDF document in landscape orientation.
            PdfDocument document = new PdfDocument();
            document.PageSettings.Orientation = PdfPageOrientation.Landscape;
            document.PageSettings.Size = PdfPageSize.A4;

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Draw the decorated certificate template as the page background.
            string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "Data", "CertificateTemplate.jpeg");
            using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                PdfBitmap templateImage = new PdfBitmap(imageStream);
                graphics.DrawImage(templateImage, 0, 0, page.Size.Width, page.Size.Height);
            }

            //Load TrueType fonts (regular and bold) shipped with the sample.
            FileStream regularStream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "Fonts", "arial.ttf"), FileMode.Open, FileAccess.Read);
            FileStream boldStream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "Fonts", "arialbd.ttf"), FileMode.Open, FileAccess.Read);
            PdfTrueTypeFont headingFont = new PdfTrueTypeFont(boldStream, 22, PdfFontStyle.Bold);
            PdfTrueTypeFont nameFont = new PdfTrueTypeFont(boldStream, 24, PdfFontStyle.Bold);
            PdfTrueTypeFont bodyFont = new PdfTrueTypeFont(regularStream, 13, PdfFontStyle.Regular);
            PdfTrueTypeFont smallFont = new PdfTrueTypeFont(regularStream, 11, PdfFontStyle.Regular);

            //Page is 841 x 595 points (A4 landscape).
            float pageWidth = page.Size.Width;
            float centerX = pageWidth / 2;

            //Heading: "NATIONAL LEVEL ONLINE COMPETITION".
            PdfStringFormat centerFormat = new PdfStringFormat { Alignment = PdfTextAlignment.Center };
            graphics.DrawString("NATIONAL LEVEL ONLINE COMPETITION", headingFont, PdfBrushes.IndianRed,
                new RectangleF(0, 195, pageWidth, 30), centerFormat);

            //Competition title.
            graphics.DrawString(model.CompetitionTitle.ToUpperInvariant(), headingFont, PdfBrushes.Firebrick,
                new RectangleF(60, 235, pageWidth - 120, 60),
                new PdfStringFormat { Alignment = PdfTextAlignment.Center, LineAlignment = PdfVerticalAlignment.Middle });

            //Left column: certification text.
            float leftX = 90;
            float leftWidth = 330;
            graphics.DrawString("This is to certify that", bodyFont, PdfBrushes.Black,
                new RectangleF(leftX, 320, leftWidth, 20));
            graphics.DrawString(model.ParticipantName, nameFont, PdfBrushes.IndianRed,
                new RectangleF(leftX, 345, leftWidth, 30));
            graphics.DrawString("Has Successfully Participated in", bodyFont, PdfBrushes.Black,
                new RectangleF(leftX, 385, leftWidth, 20));
            graphics.DrawString("National Level Competition-2025", nameFont, PdfBrushes.Black,
                new RectangleF(leftX, 408, leftWidth, 30));

            //Right column: description paragraph.
            float rightX = 470;
            float rightWidth = 280;
            graphics.DrawString(model.Description, bodyFont, PdfBrushes.Black,
                new RectangleF(rightX, 320, rightWidth, 120));

            //Bottom: organizer, date and exam mode.
            PdfStringFormat centerTopFormat = new PdfStringFormat { Alignment = PdfTextAlignment.Center, LineAlignment = PdfVerticalAlignment.Middle };
            graphics.DrawString("Organized by :", smallFont, PdfBrushes.Black,
                new RectangleF(leftX, 465, 200, 15), centerTopFormat);
            graphics.DrawString("Minhaj Publications India", smallFont, PdfBrushes.Black,
                new RectangleF(leftX, 482, 200, 15), centerTopFormat);
            graphics.DrawString("Vadodara - Gujarat", smallFont, PdfBrushes.Black,
                new RectangleF(leftX, 499, 200, 15), centerTopFormat);

            graphics.DrawString($"Date: {model.DateText}", smallFont, PdfBrushes.Black,
                new RectangleF(340, 470, 180, 15), centerTopFormat);
            graphics.DrawString($"Exam Mode: {model.ExamMode}", smallFont, PdfBrushes.Black,
                new RectangleF(340, 488, 180, 15), centerTopFormat);

            //Signatory block on the right.
            float signX = 570;
            graphics.DrawString("Saiyed Nadeali Hasanali", smallFont, PdfBrushes.Black,
                new RectangleF(signX, 465, 210, 15), centerTopFormat);
            graphics.DrawString("Director", smallFont, PdfBrushes.Black,
                new RectangleF(signX, 482, 210, 15), centerTopFormat);
            graphics.DrawString("Minhaj Publication India", smallFont, PdfBrushes.Black,
                new RectangleF(signX, 499, 210, 15), centerTopFormat);

            //Save the PDF document into memory stream.
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;
            document.Close(true);

            //Download the generated PDF file.
            string fileName = $"Certificate-{model.ParticipantName.Replace(' ', '_')}.pdf";
            return File(stream, "application/pdf", fileName);
        }

        private List<SelectListItem> GetExamModes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Online", Value = "Online" },
                new SelectListItem { Text = "Offline", Value = "Offline" }
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
