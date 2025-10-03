using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;


    // Initialize HTML to PDF converter
    HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
    //Convert the HTML to PDF without margins. 
    BlinkConverterSettings settings = new BlinkConverterSettings();
    settings.Margin.All = 0;
    settings.ViewPortSize = new Size(1024, 768); // Set the viewport size for rendering
    htmlConverter.ConverterSettings = settings;

    // Load HTML content from a file
    string html = File.ReadAllText(Path.GetFullPath(@"Data/Sample.html"));

    // Convert HTML to PDF
    using (PdfDocument document = htmlConverter.Convert(html, ""))
    {
        if (Directory.Exists("Output") == false)
        {
            Directory.CreateDirectory("Output");
        }
            // Save the converted PDF document
            document.Save(Path.GetFullPath(@"Output/Output.pdf"));
    }
    htmlConverter.Close();

    //Load the converted document
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(Path.GetFullPath(@"Output/Output.pdf")))
    {

        // Define pages requiring headers
        HashSet<int> pagesWithHeaders = new HashSet<int> { 0, 2 }; // 0-based: pages 1 and 3

        // Create a new PDF document
        using (PdfDocument finalDocument = new PdfDocument())
        {
            // Create a section for the new document
            PdfSection section = finalDocument.Sections.Add();
            // Set margins for the section
            section.PageSettings.Margins.All = 0;
            // Iterate over each page in the original document
            for (int i = 0; i < loadedDocument.Pages.Count; i++)
            {
                bool hasHeaderAndFooter = pagesWithHeaders.Contains(i);
                if (hasHeaderAndFooter)
                {
                    // Set the page size to match the original document by allocating space for headers and footer.
                    section.PageSettings.Size = loadedDocument.Pages[i].Size;
                }
                else
                {
                    // Set the page size to match the original document
                    section.PageSettings.Size = loadedDocument.Pages[i].Size;
                }
                // Create a new page in the final document
                PdfPage destPage = section.Pages.Add();

                // Copy content from the loaded document                
                PdfTemplate contentTemplate = loadedDocument.Pages[i].CreateTemplate();

                if (hasHeaderAndFooter)
                {
                    //Define the font for header               
                    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                    //Draw header and footer
                    AddHeaderAndFooter(destPage, "PDF Page Header Content", "PDF Page Footer Content", font);
                    //Draw the template 
                    destPage.Graphics.DrawPdfTemplate(contentTemplate, new PointF(0, 50)); //50 Header height
                }
                else
                {
                    // Draw the content on the destination page
                    destPage.Graphics.DrawPdfTemplate(contentTemplate, new PointF(0, 0));
                }
            }
                // Save the converted PDF document
                finalDocument.Save(Path.GetFullPath(@"Output/Output-With-HeaderandFooter.pdf"));
        }
    }

static void AddHeaderAndFooter(PdfPage page, string headerText, string footerText, PdfFont font)
{
    // Draw header
    page.Graphics.DrawLine(PdfPens.Gray, new PointF(0, 50), new PointF(page.GetClientSize().Width, 50));

    //Measure the header text
    SizeF textSize = font.MeasureString(headerText);
    page.Graphics.DrawString(headerText, font, PdfBrushes.Red, new PointF((page.GetClientSize().Width - textSize.Width) / 2, (50 - textSize.Height) / 2));

    // Draw footer
    page.Graphics.DrawLine(PdfPens.Gray, new PointF(0, page.GetClientSize().Height - 50), new PointF(page.GetClientSize().Width, page.GetClientSize().Height - 50));
    page.Graphics.DrawString(footerText, font, PdfBrushes.Green, new PointF(10, page.GetClientSize().Height - 50)); //50 Footer height
}
