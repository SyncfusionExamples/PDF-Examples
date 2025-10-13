using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Drawing;

class Program
{
    static void Main()
    {
        // HTML content to be converted
        string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Text Formatting Example</title>
</head>
<body>
    <p>Generic items.</p>
    <p><b>Bold</b></p>
    <p><i><b>Italic and Bold</b></i></p>
    <p><i><b><s>Italic and Bold And Strikethrough</s></b></i></p>
    <p><i><b><s><u>Italic and Bold and strikethrough and underlined</u></s></b></i></p>
    <a href=""https://www.google.com/"">Google</a>
</body>
</html>";

        // Initialize the HTML to PDF converter
        HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

        // Configure Blink converter settings
        BlinkConverterSettings blinkSettings = new BlinkConverterSettings
        {
            PdfPageSize = PdfPageSize.A4,
            ViewPortSize = new Syncfusion.Drawing.Size(1280, 0),
            Margin = new PdfMargins { Top = 0, Bottom = 0, Left = 0, Right = 0 },
            Orientation = PdfPageOrientation.Portrait,
            EnableHyperLink = true,
            EnableJavaScript = false,
            EnableForm = false,
            EnableOfflineMode = true,
            EnableLocalFileAccess = true,
            AdditionalDelay = 0
        };

        htmlConverter.ConverterSettings = blinkSettings;

        // Convert HTML string to PDF document
        using (PdfDocument document = htmlConverter.Convert(htmlContent, string.Empty))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the document to memory stream
                document.Save(memoryStream);
                document.Close(true); // Close and dispose the original document

                memoryStream.Position = 0; // Reset stream position for reading

                // Load the saved PDF from memory stream
                using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(memoryStream))
                {
                    loadedDocument.EnableMemoryOptimization = true;

                    // Dictionary to store hyperlink annotations by page index
                    Dictionary<int, List<PdfLoadedAnnotation>> hyperlinkAnnotations = new Dictionary<int, List<PdfLoadedAnnotation>>();

                    for (int i = 0; i < loadedDocument.Pages.Count; i++)
                    {
                        PdfLoadedAnnotationCollection annotations = loadedDocument.Pages[i].Annotations;
                        List<PdfLoadedAnnotation> pageLinks = new List<PdfLoadedAnnotation>();

                        foreach (PdfLoadedAnnotation annotation in annotations)
                        {
                            if (annotation.Type == PdfLoadedAnnotationType.TextWebLinkAnnotation)
                            {
                                pageLinks.Add(annotation);
                            }
                        }

                        hyperlinkAnnotations[i] = pageLinks;
                    }

                    // Create a new PDF document to copy pages and annotations
                    using (PdfDocument finalDocument = new PdfDocument())
                    {
                        for (int i = 0; i < loadedDocument.Pages.Count; i++)
                        {
                            PdfPageBase sourcePage = loadedDocument.Pages[i];
                            PdfPage newPage = finalDocument.Pages.Add();

                            // Copy content from source page
                            newPage.Graphics.DrawPdfTemplate(sourcePage.CreateTemplate(), PointF.Empty);

                            // Reapply hyperlink annotations
                            if (hyperlinkAnnotations.TryGetValue(i, out var annotations))
                            {
                                foreach (PdfLoadedAnnotation annotation in annotations)
                                {
                                    if (annotation is PdfLoadedTextWebLinkAnnotation linkAnnotation)
                                    {
                                        PdfUriAnnotation uriAnnotation = new PdfUriAnnotation(annotation.Bounds, linkAnnotation.Url)
                                        {
                                            Text = linkAnnotation.Text,
                                            Border = new PdfAnnotationBorder
                                            {
                                                Width = 0,
                                                VerticalRadius = 0,
                                                HorizontalRadius = 0
                                            }
                                        };

                                        newPage.Annotations.Add(uriAnnotation);
                                    }
                                }
                            }
                        }
                        // Save the final PDF to file
                        finalDocument.Save(Path.GetFullPath(@"Output/Output.pdf"));
                    }
                }
            }
        }
    }
}