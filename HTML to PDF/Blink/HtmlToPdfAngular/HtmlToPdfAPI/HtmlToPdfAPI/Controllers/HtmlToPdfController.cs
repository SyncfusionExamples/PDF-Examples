using Microsoft.AspNetCore.Mvc;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.IO;
using System.Text;

namespace HtmlToPdfAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HtmlToPdfController : ControllerBase
    {
        public class HtmlToPdfRequest
        {
            public string HtmlContent { get; set; }
        }

        [HttpPost]
        public IActionResult ConvertHtmlToPdf([FromBody] HtmlToPdfRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.HtmlContent))
            {
                return BadRequest("HTML content is required.");
            }

            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            BlinkConverterSettings settings = new BlinkConverterSettings();
            htmlConverter.ConverterSettings = settings;

            PdfDocument document = htmlConverter.Convert(request.HtmlContent, "");

            using MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;

            return File(stream.ToArray(), "application/pdf", "ConvertedFile.pdf");
        }
        [HttpOptions]
        public IActionResult Options()
        {
            return Ok();
        }
    }
}
