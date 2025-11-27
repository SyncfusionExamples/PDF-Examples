using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("your License key");

        string inputFolder = Path.GetFullPath("../../../Data/");
        string outputFolder = Path.GetFullPath("../../../Output/");
        Directory.CreateDirectory(outputFolder);
        string Outputfile = "DocumentCreation";
        int[] count = { 1,  100,  500, 1000 };
        string content = "Syncfusion is a leading provider of software components and frameworks for enterprise application development, established in 2001 and headquartered in Research Triangle Park, North Carolina. Over the past two decades, the company has grown to become one of the most comprehensive providers of UI controls, frameworks, and development tools for modern application development across multiple platforms. With a global presence serving customers in over 125 countries, Syncfusion has established itself as a trusted partner for developers building modern, scalable, and feature-rich applications.\r\n\r\nSyncfusion specializes in providing over 1,800+ components and frameworks that span across various platforms including web, mobile, and desktop applications. Their extensive product portfolio includes controls for popular frameworks such as ASP.NET Core, ASP.NET MVC, Blazor, JavaScript, Angular, React, Vue.js, jQuery, Xamarin, .NET MAUI, Flutter, WinForms, WPF, WinUI, and UWP. This comprehensive coverage ensures that developers can maintain consistency and quality across different platforms while using familiar tools and components. The company's offerings are specifically designed for enterprise-grade applications with features that include high performance optimization for handling large datasets, WCAG 2.2 compliant accessibility standards, built-in localization support for internationalization, comprehensive theming capabilities, and responsive designs that work seamlessly on touch-enabled devices.\r\n\r\nOne of Syncfusion's core strengths lies in its extensive library of professionally designed UI components and controls. The product suite includes sophisticated data grids with advanced filtering and editing capabilities, comprehensive charting libraries featuring dozens of chart types from basic visualizations to advanced financial charts and 3D representations, powerful schedulers and calendar controls, diagram libraries supporting flowcharts and organizational charts, spreadsheet components, PDF viewers and editors, word processors, and much more. These components are known for their high performance, rich feature sets, consistent design across platforms, and ability to handle complex enterprise requirements. Additionally, Syncfusion provides powerful file format libraries that enable developers to create, read, edit, and convert various file formats including PDF documents, Excel spreadsheets, Word documents, and PowerPoint presentations without requiring Microsoft Office or Adobe dependencies, making them ideal for server-side and cloud-based applications.\r\n\r\nSyncfusion demonstrates exceptional commitment to developer productivity and experience through multiple channels. The company provides extensive documentation with comprehensive examples and API references, hundreds of demo applications showcasing component capabilities and best practices, industry-leading technical support with direct access to experienced engineers, regular updates with new features and improvements, and seamless integration with Visual Studio and other popular IDEs. This focus on developer experience extends to their flexible licensing options, which include commercial licenses for businesses and enterprises, a notable Community License program that provides free access to the complete product suite for individual developers and small businesses with less than $1 million in annual gross revenue, and free educational licenses for students and educators. This Community License program has been particularly impactful in making professional-grade components accessible to startups, freelancers, and small development teams who might otherwise be unable to afford enterprise-level tools.\r\n\r\nThe company continues to innovate and push boundaries in the development tools space.";
        PdfFont font = new PdfStandardFont(Syncfusion.Pdf.Graphics.PdfFontFamily.Helvetica, 12);
        FileStream fileStream = File.OpenRead("../../../Data/logo.png");
        foreach (int numberOfPages in count)
        {            
            string outputPath = Path.Combine(outputFolder, Outputfile);
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {  
                PdfDocument document = new PdfDocument();
                fileStream.Position = 0;
                PdfBitmap image = new PdfBitmap(fileStream);
                for (int i=0; i< numberOfPages; i++)
                {
                    PdfPage page = document.Pages.Add();
                    page.Graphics.DrawImage(image, 0, 0, 100, 100);
                    page.Graphics.DrawString(content, font, PdfBrushes.Black, new RectangleF(0, 110, page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height));

                }
                // Save the document to Output folder
                document.Save(outputPath + numberOfPages+".pdf");      
                document.Close(true);
                stopwatch.Stop();
                Console.WriteLine($"Document Creation Number of pages {numberOfPages} in {stopwatch.Elapsed.TotalSeconds} seconds");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing : {ex.Message}");
            }
        }
    }
}