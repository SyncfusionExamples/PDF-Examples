using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

//Initialize HTML to PDF converter 
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
// HTML string with image using CSS for explicit sizing
string htmlString = @"
<html> <body style='text-align:center;font-family:Arial, Helvetica, sans-serif;'>
<br /> <img src='syncfusion_logo.gif' alt='Syncfusion logo' style='width:700px; height:200px;' />
<p style='font-size:72px; margin:0 auto;'>Hello World</p> </body> </html>";
//Path to the resources
string baseUrl = Path.GetFullPath(@"Data/");
//Convert HTML string to PDF
using (PdfDocument document = htmlConverter.Convert(htmlString, baseUrl))
{
    //Save the PDF document 
    document.Save(Path.GetFullPath(@"Output/Output.pdf"));
}
